namespace SurveyBasket.API.Contracts.Results
{
    public record VotesPerAnswerResponse(
    string Answer,
    int Count
);
}
