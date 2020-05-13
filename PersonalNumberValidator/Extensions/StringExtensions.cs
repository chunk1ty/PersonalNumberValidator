using System.Linq;

namespace PersonalNumberValidator.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsNumber(this string str)
        {
            return str.All(char.IsDigit);
        }
    }
}
