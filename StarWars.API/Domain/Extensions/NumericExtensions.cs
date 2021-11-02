using System;

namespace StarWars.API.Domain.Extensions
{
    public static class NumericExtensions
    {
        public static double ToDouble(this String value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        
        public static long ToLong(this String value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        
        public static int ToInt(this String value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
    }
}