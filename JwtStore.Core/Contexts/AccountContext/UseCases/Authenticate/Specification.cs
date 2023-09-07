using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Password.Length, 40, "Password", "Password must contain less than 40 characters!")
            .IsGreaterThan(request.Password.Length, 8, "Password", "Password must contain more than 8 characters!")
            .IsEmail(request.Email, "EMAIL", "Invalid E-mail!");
}