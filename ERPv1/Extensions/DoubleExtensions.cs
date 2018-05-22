using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPv1.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToEuro(this double value)
        {
            return value.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
        }
    }
}