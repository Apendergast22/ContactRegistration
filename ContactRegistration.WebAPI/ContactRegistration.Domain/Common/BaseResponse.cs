
namespace ContactRegistration.Domain.Common;
/// <summary>
/// Defines the <see cref="BaseResponse" />.
/// </summary>
public abstract class BaseResponse
{
    /// <summary>
    /// Gets or sets the MessageSummary.
    /// </summary>
    public MessagesSummary? MessageSummary { get; set; }
}

