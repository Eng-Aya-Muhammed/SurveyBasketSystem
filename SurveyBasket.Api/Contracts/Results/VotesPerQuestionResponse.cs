namespace SurveyBasket.API.Contracts.Results
{
    public record VotesPerQuestionResponse(
    string Question,
    IEnumerable<VotesPerAnswerResponse> SelectedAnswers
);
}
