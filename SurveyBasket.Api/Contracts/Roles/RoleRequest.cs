namespace SurveyBasket.API.Contracts.Roles
{
    public record RoleRequest(
    string Name,
    IList<string> Permissions
);
}
