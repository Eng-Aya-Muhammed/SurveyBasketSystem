using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace SurveyBasket.API.Contracts.Authentication
{
    public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
    {
        public ResendConfirmationEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
