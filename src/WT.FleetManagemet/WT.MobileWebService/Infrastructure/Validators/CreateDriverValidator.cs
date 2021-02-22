using FluentValidation;
using WT.MobileWebService.Contract.V1.Requests;

namespace WT.MobileWebService.Infrastructure.Validators
{
    public class CreateDriverValidator : AbstractValidator<CreateDriverRequest>
    {
        public CreateDriverValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Family).MinimumLength(3).MaximumLength(50);
            //RuleFor(x => x.PhoneNumber).Matches(@"^\(? ([0 - 9]{ 3})\)?[-]?([0 - 9]{ 3})[-]?([0 - 9]{ 4})$");
        }
    }
}
