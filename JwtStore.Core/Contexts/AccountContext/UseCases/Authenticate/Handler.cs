using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;
using MediatR;
using JwtStore.Core.Contexts.AccountContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate request

        try
        {
            var result = Specification.Ensure(request);
            if (!result.IsValid)
                return new Response("Invalid request", 400, result.Notifications);
        }
        catch (Exception)
        {
            return new Response("Unable to validate request", 500);
        }

        #endregion

        #region Recovering user
        User? user;

        try
        {
            user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (user is null)
                return new Response("User not found", 404);
        }
        catch
        {
            return new Response("Failed to fetch user", 500);
        }

        #endregion

        #region Check password is valid

        if (!user.Password.Challenge(request.Password))
            return new Response("User or password are invalid", 400);

        #endregion

        #region Make sure the account is verified

        try
        {
            if (!user.Email.Verification.IsActive)
                return new Response("Inactive account", 400);
        }
        catch
        {
            return new Response("Unable to verify your profile", 500);
        }

        #endregion

        #region Return data

        try
        {
            var data = new ResponseData
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles.Select(role => role.Name).ToArray()
            };
            return new Response(string.Empty, data);
        }
        catch
        {
            return new Response("Unable to get profile data", 500);
        }

        #endregion
    }
}