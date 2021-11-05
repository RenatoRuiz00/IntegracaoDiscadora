using System;

namespace Operacao.Shared.Utils
{
    public class Converter
    {
        public static bool ToBool(object obj)
        {
            try
            {
                return bool.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
        }

        public static DateTime TimeZone(DateTime dt)
        {
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"); // Brasilia/BRA
            DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, kstZone);
            return dateTimeBrasilia;
        }

        public static DateTime? ToDateTime(object obj)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return null;
            }
        }
    }
}
