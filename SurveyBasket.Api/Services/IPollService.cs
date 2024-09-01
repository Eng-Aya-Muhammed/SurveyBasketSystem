﻿using SurveyBasket.API.Abstractions;
using SurveyBasket.API.Contracts.Polls;

namespace SurveyBasket.API.Services
{
    public interface IPollService
    {
        Task<IEnumerable<PollResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PollResponse>> GetCurrentAsyncV1(CancellationToken cancellationToken = default);
        Task<IEnumerable<PollResponseV2>> GetCurrentAsyncV2(CancellationToken cancellationToken = default);
        Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, PollRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default);
    }
}