namespace Checkout.Domain.ValueObjects;

public sealed record Address
{
    /// <summary>
    /// Gets the first name of the person associated with the address.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name of the person associated with the address.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the email address of the person associated with the address.
    /// </summary>
    public string? EmailAddress { get; }

    /// <summary>
    /// Gets the address line of the person associated with the address.
    /// </summary>
    public string AddressLine { get; }

    /// <summary>
    /// Gets the country of the person associated with the address.
    /// </summary>
    public string Country { get; }

    /// <summary>
    /// Gets the state of the person associated with the address.
    /// </summary>
    public string State { get; }

    /// <summary>
    /// Gets the zip code of the person associated with the address.
    /// </summary>
    public string ZipCode { get; }
    
    protected Address()
    {
    }

    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}