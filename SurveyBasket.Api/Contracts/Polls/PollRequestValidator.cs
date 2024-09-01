using FluentValidation;
using SurveyBasket.API.Contracts.Polls;

namespace SurveyBasket.API.Contracts.Authentication
{
    public class PollRequestValidator : AbstractValidator<PollRequest>
    {
        public PollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Summary)
                .NotEmpty()
                .Length(3, 1500);

            RuleFor(x => x.StartsAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.EndsAt)
                .NotEmpty();

            RuleFor(x => x)
                .Must(HasValidDates)
                .WithName(nameof(PollRequest.EndsAt))
                .WithMessage("{PropertyName} must be greater than or equals start date");
        }

        private bool HasValidDates(PollRequest pollRequest)
        {
            return pollRequest.EndsAt >= pollRequest.StartsAt;
        }
    }
}
