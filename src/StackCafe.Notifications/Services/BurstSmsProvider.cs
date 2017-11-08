using StackCafe.Notifications.Configuration;
//using TransmitSms;

namespace StackCafe.Notifications.Services
{
    public class BurstSmsProvider : ISmsProvider
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public BurstSmsProvider(SmsApiKey apiKey, SmsApiSecret apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        public void Send(string phoneNumber, string message)
        {


            string[] sendTo = { phoneNumber };
            
            //var manager = new TransmitSmsWrapper(_apiKey, _apiSecret, "https://api.transmitsms.com/");
            
            
            
            //// Send an SMS via SendSms

            //var response = manager.SendSms(message, sendTo, "StackCafe", null, null, "", "", 0);



        }
    }
}