
namespace ContactRegistration.Application.Validators;

public class ContactValidator : AbstractValidator<ContactModel>
{
    public ContactValidator()
    {
        ////RuleFor(x => x.Id)
        ////    .NotNull()
        ////    .WithErrorCode(CustomerResponseMessages.Instance.UserIdRequired.Code)
        ////    .WithMessage(CustomerResponseMessages.Instance.UserIdRequired.Text)
        ////    .MinimumLength(1)
        ////    .WithErrorCode(CustomerResponseMessages.Instance.UserIdRequired.Code)
        ////    .WithMessage(CustomerResponseMessages.Instance.UserIdRequired.Text);

        ////RuleFor(x => x.FirstName)
        ////    .NotNull()
        ////        .WithErrorCode(CustomerResponseMessages.Instance.FirstNameRequired.Code)
        ////        .WithMessage(CustomerResponseMessages.Instance.FirstNameRequired.Text)
        ////    .MinimumLength(1)
        ////       .WithErrorCode(CustomerResponseMessages.Instance.FirstNameRequired.Code)
        ////       .WithMessage(CustomerResponseMessages.Instance.FirstNameRequired.Text)
        ////    .MaximumLength(50)
        ////        .WithErrorCode(CustomerResponseMessages.Instance.FirstNameLenghtExceed.Code)
        ////        .WithMessage(CustomerResponseMessages.Instance.FirstNameLenghtExceed.Text);

        RuleFor(contact => contact.Emails)
                .Must(HaveOnePrimaryEmail)
                .WithMessage("One and only one email should be set as primary");
    }

    private bool HaveOnePrimaryEmail(IList<EmailModel>? emails)
    {        
        var primaryCount = emails?.Count(e => e.IsPrimary);        
        return primaryCount == 1;
    }
}