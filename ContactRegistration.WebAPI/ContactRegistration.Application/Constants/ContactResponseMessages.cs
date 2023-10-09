
namespace ContactRegistration.Application.Constants;

public class ContactResponseMessages
{
    /// <summary>
    /// The instance
    /// </summary>
    private static readonly ContactResponseMessages instance = new();

    /// <summary>
    /// Gets the instance.
    /// </summary>
    public static ContactResponseMessages Instance => instance;

    /// <summary>
    /// Gets the error occured.
    /// </summary>
    public Message ErrorOccured { get; } = new() { Code = "6000", Title = "An error has occured", Text = "An error has occured.", MessageDisplayType = nameof(MessageDisplayTypes.All), MessageIndicatorType = nameof(MessageIndicatorTypes.Error) };

    /// <summary>
    /// The user updated successfully
    /// </summary>
    public Message UpdatedSuccessfully { get; } = new() { Code = "7000", Title = "Contact updated successfully", Text = "Contact updated successfully.", MessageDisplayType = nameof(MessageDisplayTypes.All), MessageIndicatorType = nameof(MessageIndicatorTypes.Information) };

    /// <summary>
    /// The user created successfully
    /// </summary>
    public Message CreatedSuccessfully { get; } = new() { Code = "7001", Title = "Contact created successfully", Text = "Contact updated successfully.", MessageDisplayType = nameof(MessageDisplayTypes.All), MessageIndicatorType = nameof(MessageIndicatorTypes.Information) };

    /// <summary>
    /// Gets the deleted successfully.
    /// </summary>    
    public Message DeletedSuccessfully { get; } = new() { Code = "8000", Title = "Contact deleted successfully", Text = "Contact deleted successfully.", MessageDisplayType = nameof(MessageDisplayTypes.All), MessageIndicatorType = nameof(MessageIndicatorTypes.Information) };
}