using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Name.Length, 160, "Name", "Name must contain a maximum of 160 characters!")
            .IsGreaterThan(request.Name.Length, 3, "Name", "Name must contain a minimum of 3 characters!")
            .IsLowerThan(request.Password.Length, 40, "Password", "Password must contain a maximum of 40 characters!")
            .IsGreaterThan(request.Password.Length, 8, "Password", "Name must contain a minimum of 8 characters!")
            .IsEmail(request.Email, "Email", "Invalid E-mail!");
}