using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Contracts.Results;

namespace SurveyBasket.API.Services
{
    public interface IResultService
    {
        Task<Result<PollVotesResponse>> GetPollVotesAsync(int pollId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<VotesPerDayResponse>>> GetVotesPerDayAsync(int pollId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<VotesPerQuestionResponse>>> GetVotesPerQuestionAsync(int pollId, CancellationToken cancellationToken = default);
    }
}
