using Serilog;
using StackCafe.Notifications.Configuration;
using TransmitSms;

namespace StackCafe.Notifications.Services
{
    public class BurstSmsProvider : ISmsProvider
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly ILogger _logger;

        public BurstSmsProvider(SmsApiKey apiKey, SmsApiSecret apiSecret, ILogger logger)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _logger = logger;
        }

        public void Send(string phoneNumber, string message)
        {


            string[] sendTo = { phoneNumber };
            
            var manager = new TransmitSmsWrapper(_apiKey, _apiSecret, "https://api.transmitsms.com/");
            
            var response = manager.SendSms(message, sendTo, "StackCafe", null, null, "", "", 0);
            
            _logger.Information("Message to {phoneNumber} sent with status: {Code}", phoneNumber, response.Error.Code);


        }
    }
}