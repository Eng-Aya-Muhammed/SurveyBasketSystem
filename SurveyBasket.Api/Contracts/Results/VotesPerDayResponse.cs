namespace SurveyBasket.API.Contracts.Results
{
    public record VotesPerDayResponse(
    DateOnly Date,
    int NumberOfVotes
);
}
