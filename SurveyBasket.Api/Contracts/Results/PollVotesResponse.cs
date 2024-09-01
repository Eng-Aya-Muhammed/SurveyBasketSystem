namespace SurveyBasket.API.Contracts.Results
{
    public record PollVotesResponse(
    string Title,
    IEnumerable<VoteResponse> Votes
);
}
