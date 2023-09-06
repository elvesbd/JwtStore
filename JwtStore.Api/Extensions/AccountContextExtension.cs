namespace JwtStore.Api.Extensions;

public static class AccountExtension
{
    public static void AddAccountContext(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddTransient
        <
            JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
            JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Repository
        >();

        builder.Services.AddTransient
        <
            JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
            JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Repository
        >();

        #endregion
    }

    public static void MapAccountEndpoints(this WebApplication builder)
    {
        #region Create



        #endregion
    }
}