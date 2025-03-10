using System.Text.RegularExpressions;

namespace Vilas.Utils.Text
{
    public  static class Email
    {
        public static bool Validate(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }
    }
}
