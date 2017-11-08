namespace StackCafe.Notifications.Services
{
    public interface ISmsProvider
    {
        void Send(string phoneNumber, string message);
    }
}