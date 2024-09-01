using Mapster;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Contracts.Votes;
using SurveyBasket.API.Entities;
using SurveyBasket.API.Errors;
using SurveyBasket.API.Persistence;

namespace SurveyBasket.API.Services
{
    public class VoteService(ApplicationDbContext context) : IVoteService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
        {
            var hasVote = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken);

            if (hasVote)
                return Result.Failure(VoteErrors.DuplicatedVote);

            var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId && x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);

            if (!pollIsExists)
                return Result.Failure(PollErrors.PollNotFound);

            var availableQuestions = await _context.Questions
                .Where(x => x.PollId == pollId && x.IsActive)
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

            if (!request.Answers.Select(x => x.QuestionId).SequenceEqual(availableQuestions))
                return Result.Failure(VoteErrors.InvalidQuestions);

            var vote = new Vote
            {
                PollId = pollId,
                UserId = userId,
                VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()
            };

            await _context.AddAsync(vote, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
