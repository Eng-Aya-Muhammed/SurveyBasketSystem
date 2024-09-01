namespace SurveyBasket.API.Contracts.Votes
{
    public record VoteAnswerRequest(
    int QuestionId,
    int AnswerId
);
}
