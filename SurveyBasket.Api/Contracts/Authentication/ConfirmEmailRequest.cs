﻿namespace SurveyBasket.API.Contracts.Authentication
{
    public record ConfirmEmailRequest(
    string UserId,
    string Code
);
}
