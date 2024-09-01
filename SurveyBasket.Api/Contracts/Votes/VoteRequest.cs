namespace SurveyBasket.API.Contracts.Votes
{
    public record VoteRequest(
    IEnumerable<VoteAnswerRequest> Answers
);
}
