using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public class Password : ValueObject
{
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    private const string Special = "!@#$%^&*(){}[]";

    public string Hash { get; set; } = string.Empty;
    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
}