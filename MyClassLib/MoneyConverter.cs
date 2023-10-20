using System;
using System.Collections.Generic; 
namespace MyClassLib.WordOfTanks
{
    public static class MoneyConverter
    {
        public static decimal ConvertToTenge(decimal amount, string currency, Dictionary<string, decimal> exchangeRates)
        {
            if (exchangeRates.TryGetValue(currency, out decimal rate))
            {
                return amount * rate;
            }
            else if (currency == "KZT")
            {
                return amount; // если деньги уже в тенге, то оставляем без изменения.
            }
            else
            {
                throw new ArgumentException("Неподдерживаемая валюта");
            }
        }

        public static void SetExchangeRate(string currency, decimal rate, Dictionary<string, decimal> exchangeRates)
        {
            if (exchangeRates.ContainsKey(currency))
            {
                exchangeRates[currency] = rate;
            }
            else
            {
                exchangeRates.Add(currency, rate);
            }
        }
    }
}
