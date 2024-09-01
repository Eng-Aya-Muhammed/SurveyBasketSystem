﻿using FluentValidation;

namespace SurveyBasket.API.Contracts.Votes
{
    public class VoteAnswerRequestValidator : AbstractValidator<VoteAnswerRequest>
    {
        public VoteAnswerRequestValidator()
        {
            RuleFor(x => x.QuestionId)
                .GreaterThan(0);

            RuleFor(x => x.AnswerId)
                .GreaterThan(0);
        }
    }
}
