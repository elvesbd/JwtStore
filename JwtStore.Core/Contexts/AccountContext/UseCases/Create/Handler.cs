using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Exceptions;

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
        #endregion

        #region 03 - Verify if user existis
        #endregion

        #region 04 - Persist data
        #endregion

        #region 05 - Send welcome e-mail
        #endregion
    }
}