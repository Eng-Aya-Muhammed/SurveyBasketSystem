namespace SurveyBasket.API.Services
{
    public interface INotificationService
    {
        Task SendNewPollsNotification(int? pollId = null);
    }
}
