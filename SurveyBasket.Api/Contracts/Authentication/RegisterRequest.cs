﻿namespace SurveyBasket.API.Contracts.Authentication
{
    public record RegisterRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName
);
}
