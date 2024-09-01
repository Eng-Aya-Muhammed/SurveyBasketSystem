using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Contracts.Votes;

namespace SurveyBasket.API.Services
{
    public interface IVoteService
    {
        Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);
    }
}
