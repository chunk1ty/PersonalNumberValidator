namespace PersonalNumberValidator.Extensions
{
    internal static class CharExtensions
    {
        public static int GetDigit(this char digit)
        {
            return digit - '0';
        }
    }
}
