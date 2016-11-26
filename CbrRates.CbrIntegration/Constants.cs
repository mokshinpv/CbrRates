using System.Globalization;

namespace CbrRates.CbrIntegration
{
    internal static class Constants
    {
        public const string RequestDateFormat = "dd/MM/yyyy";
        public const string ResponseDateFormat = "dd.MM.yyyy";

        public const int RuLcid = 1049;
        public static readonly CultureInfo RuCulture = new CultureInfo(RuLcid);
    }
}
