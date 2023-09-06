using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Exceptions;
using JwtStore.Core.Contexts.AccountContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public Handler(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01 - Validate request

        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Invalid request", 400, res.Notifications);
        }
        catch
        {
            return new Response("Unable to validate your request", 500);
        }

        #endregion

        #region 02 - Generate objects

        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        #endregion

        #region 03 - Verify if user existis

        try
        {
            var existis = await _repository.AnyAsync(request.Email, cancellationToken);
            if (existis)
                return new Response("E-mail already in use", 400);
        }
        catch
        {
            return new Response("Failed to verify registered E-mail!", 500);
        }

        #endregion

        #region 04 - Persist data
        #endregion

        #region 05 - Send welcome e-mail
        #endregion
    }
}