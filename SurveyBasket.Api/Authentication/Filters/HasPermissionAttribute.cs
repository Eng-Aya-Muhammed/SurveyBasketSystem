using Microsoft.AspNetCore.Authorization;

namespace SurveyBasket.API.Authentication.Filters
{
    public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
    {
    }
}
