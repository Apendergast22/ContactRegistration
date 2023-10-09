
namespace ContactRegistration.Domain.Entities;

[Table("email")]
public class Email
{
    /// <summary>
    /// Gets or sets the email identifier.
    /// </summary>
    /// <value>
    /// The email identifier.
    /// </value>
    public long EmailId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is primary.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is primary; otherwise, <c>false</c>.
    /// </value>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the Contact identifier.
    /// </summary>
    /// <value>
    /// The Contact identifier.
    /// </value>
    public long ContactId { get; set; }

    /// <summary>
    /// Gets or sets the Contact.
    /// </summary>
    /// <value>
    /// The Contact.
    /// </value>
    public Contact Contact{ get; set; } = new Contact();
}
