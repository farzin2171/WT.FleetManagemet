using FluentValidation;
using WT.MobileWebService.Contract.V1.Requests;

namespace WT.MobileWebService.Validators
{
    public class CreateLocationRequestValidator:AbstractValidator<CreateLocationRequest>
    {
        public CreateLocationRequestValidator()
        {
            RuleFor(x => x.Lat).GreaterThan(0).LessThan(100);
            RuleFor(x => x.Lon).GreaterThan(0).LessThan(100);
        }
    }
}
