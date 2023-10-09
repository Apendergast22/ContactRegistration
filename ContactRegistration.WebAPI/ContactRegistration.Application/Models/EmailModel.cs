
namespace ContactRegistration.Application.Models;

public class EmailModel
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
}
