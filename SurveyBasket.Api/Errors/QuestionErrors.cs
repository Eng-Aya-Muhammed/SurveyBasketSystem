using SurveyBasket.API.Abstractions;

namespace SurveyBasket.API.Errors
{
    public static class QuestionErrors
    {
        public static readonly Error QuestionNotFound =
            new("Question.NotFound", "No question was found with the given ID", StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedQuestionContent =
            new("Question.DuplicatedContent", "Another question with the same content is already exists", StatusCodes.Status409Conflict);
    }
}
