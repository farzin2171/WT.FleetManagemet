using FluentValidation;
using WT.MobileWebService.Contract.V1.Requests;

namespace WT.MobileWebService.Infrastructure.Validators
{
    public class CreateCustomerInformationRequestValidator:AbstractValidator<CreateCustomerInformationRequest>
    {
        public CreateCustomerInformationRequestValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
