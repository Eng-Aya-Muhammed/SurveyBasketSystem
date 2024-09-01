using Microsoft.EntityFrameworkCore;
using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Contracts.Results;
using SurveyBasket.API.Errors;
using SurveyBasket.API.Persistence;

namespace SurveyBasket.API.Services
{
    public class ResultService(ApplicationDbContext context) : IResultService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Result<PollVotesResponse>> GetPollVotesAsync(int pollId, CancellationToken cancellationToken = default)
        {
            var pollVotes = await _context.Polls
                .Where(x => x.Id == pollId)
                .Select(x => new PollVotesResponse(
                    x.Title,
                    x.Votes.Select(v => new VoteResponse(
                        $"{v.User.FirstName} {v.User.LastName}",
                        v.SubmittedOn,
                        v.VoteAnswers.Select(a => new QuestionAnswerResponse(
                            a.Question.Content,
                            a.Answer.Content
                        ))
                    ))
                ))
                .SingleOrDefaultAsync(cancellationToken);

            return pollVotes is null
                ? Result.Failure<PollVotesResponse>(PollErrors.PollNotFound)
                : Result.Success(pollVotes);
        }

        public async Task<Result<IEnumerable<VotesPerDayResponse>>> GetVotesPerDayAsync(int pollId, CancellationToken cancellationToken = default)
        {
            var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

            if (!pollIsExists)
                return Result.Failure<IEnumerable<VotesPerDayResponse>>(PollErrors.PollNotFound);

            var votesPerDay = await _context.Votes
                .Where(x => x.PollId == pollId)
                .GroupBy(x => new { Date = DateOnly.FromDateTime(x.SubmittedOn) })
                .Select(g => new VotesPerDayResponse(
                    g.Key.Date,
                    g.Count()
                ))
                .ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<VotesPerDayResponse>>(votesPerDay);
        }

        public async Task<Result<IEnumerable<VotesPerQuestionResponse>>> GetVotesPerQuestionAsync(int pollId, CancellationToken cancellationToken = default)
        {
            var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

            if (!pollIsExists)
                return Result.Failure<IEnumerable<VotesPerQuestionResponse>>(PollErrors.PollNotFound);

            var votesPerQuestion = await _context.VoteAnswers
                .Where(x => x.Vote.PollId == pollId)
                .Select(x => new VotesPerQuestionResponse(
                    x.Question.Content,
                    x.Question.Votes
                        .GroupBy(x => new { AnswerId = x.Answer.Id, AnswerContent = x.Answer.Content })
                        .Select(g => new VotesPerAnswerResponse(
                            g.Key.AnswerContent,
                            g.Count()
                        ))
                ))
                .ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<VotesPerQuestionResponse>>(votesPerQuestion);
        }
    }
}
