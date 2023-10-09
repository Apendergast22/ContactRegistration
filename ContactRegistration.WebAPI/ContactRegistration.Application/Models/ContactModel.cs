
namespace ContactRegistration.Application.Models;

public class ContactModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the birth date.
    /// </summary>
    /// <value>
    /// The birth date.
    /// </value>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the emails.
    /// </summary>
    /// <value>
    /// The emails.
    /// </value>
    public IList<EmailModel>? Emails { get; set;}
}
