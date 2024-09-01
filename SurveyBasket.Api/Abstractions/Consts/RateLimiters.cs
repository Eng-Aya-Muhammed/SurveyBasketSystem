﻿namespace SurveyBasket.Api.Abstractions.Consts
{
    public static class RateLimiters
    {
        public const string IpLimiter = "ipLimit";
        public const string UserLimiter = "userLimit";
        public const string Concurrency = "concurrency";
    }
}
