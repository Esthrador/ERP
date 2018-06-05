using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPv1.Extensions
{
    public static class DatatypeExtensions
    {
        public static string ToEuro(this double value)
        {
            return value.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
        }

        public static string ToLocalisedString(this bool value)
        {
            return value ? "Ja" : "Nein";
        }

        public static string AsContractNumber(this int value)
        {
            return value.ToString().PadLeft(8, '0');
        }
    }
}