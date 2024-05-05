using Client.Infrastructure.Enums;

namespace Client.Infrastructure.Services;

public interface IAlertService
{
    Task ShowAlertAsync(AlertType messageType, string message, string cancel = "ОК");
    Task<bool> ShowConfirmationAsync(AlertType messageType, string message,
        string accept = "Да", string cancel = "Нет");
}

public class AlertService
    : IAlertService
{
    private readonly Page _page;
    public AlertService() => _page = Application.Current?.MainPage;

    public Task ShowAlertAsync(AlertType messageType, string message, string cancel = "ОК") =>
        _page.DisplayAlert(GetAlertTitle(messageType), message, cancel);
    
    public Task<bool> ShowConfirmationAsync(AlertType messageType, string message, string accept = "Да", string cancel = "Нет") =>
        _page.DisplayAlert(GetAlertTitle(messageType), message, accept, cancel);
    
    private string GetAlertTitle(AlertType messageType)
    {
        switch (messageType)
        {
            case AlertType.Success:
                return "Успех";
            case AlertType.Error:
                return "Что то пошло не так!";
            case AlertType.Information:
                return "Информация";
            case AlertType.Exception:
                return "Исключение";
            case AlertType.Question:
                return "Вы уверены?";
            default:
                return "None";
        }
    }
}