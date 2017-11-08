namespace StackCafe.Cashier.Services
{
    public interface IBtcCurrencyConverterService
    {
        decimal ConvertToBTC(decimal amount);

        decimal ConvertToAUD(decimal amount);

        decimal GetAUDInBTC();
    }
}