using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Abstractions.Consts;
using SurveyBasket.API.Authentication.Filters;
using SurveyBasket.API.Services;

namespace SurveyBasket.API.Controllers
{
    [Route("api/polls/{pollId}/[controller]")]
    [ApiController]
    [HasPermission(Permissions.Results)]
    public class ResultsController(IResultService resultService) : ControllerBase
    {
        private readonly IResultService _resultService = resultService;

        [HttpGet("row-data")]
        public async Task<IActionResult> PollVotes([FromRoute] int pollId, CancellationToken cancellationToken)
        {
            var result = await _resultService.GetPollVotesAsync(pollId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("votes-per-day")]
        public async Task<IActionResult> VotesPerDay([FromRoute] int pollId, CancellationToken cancellationToken)
        {
            var result = await _resultService.GetVotesPerDayAsync(pollId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("votes-per-question")]
        public async Task<IActionResult> VotesPerQuestion([FromRoute] int pollId, CancellationToken cancellationToken)
        {
            var result = await _resultService.GetVotesPerQuestionAsync(pollId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
    }
}