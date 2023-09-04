using System.Text.RegularExpressions;
using JwtStore.Core.SharedContext.Extensions;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";


    public Email(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new Exception("Invalid E-mail!");

        Address = address.Trim().ToLower();

        if (Address.Length < 5)
            throw new Exception("Invalid E-mail!");

        if (!EmailRegex().IsMatch(Address))
            throw new Exception("Invalid E-mail!");
    }

    public string Address { get; }
    public string Hash => Address.ToBase64();

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new(address);

    public override string ToString()
        => Address;

    [GeneratedRegex(Pattern)]
    private partial void EmailRegex();
}