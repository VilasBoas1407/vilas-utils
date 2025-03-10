using System.Text.RegularExpressions;

namespace Vilas.Utils.Text.Validators
{
    public static partial class PasswordValidator
    {
        private static readonly string[] ObviousPasswords = { "password", "123", "qwerty", "test", "senha","teste","abc","welcome" };

        /// <summary>
        /// Checks if the password meets the following security best practices:
        /// - At least 8  characters
        /// - Contains at least 1 uppercase letter.
        /// - Contains at least 1 lowercase letter.
        /// - Contains at least 1 digit.
        /// - Contains at least 1 special character.
        /// - Does not contain obvious words or common patterns like "123", "qwerty", or "password".
        /// </summary>
        /// <param name="password">The password string to validate.</param>
        /// <returns>True if it is a strong password, otherwise false.</returns>
        public static bool IsValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            if (password.Length < 8) return false;

            if (!AtLeastOneUpperCaseLetter().IsMatch(password)) return false;


            if (!AtLeastOneLowerCaseLetter().IsMatch(password)) return false;

            if (!AtLeastOneDigit().IsMatch(password)) return false;

            if (!AtLeastOneSpecialCharacter().IsMatch(password)) return false;

            // Avoid obvious weak passwords (case-insensitive check)
            if (ObviousPasswords.Any(p => password.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0))
                return false;

            return true;
        }

        [GeneratedRegex(@"[A-Z]")]
        private static partial Regex AtLeastOneUpperCaseLetter();
        [GeneratedRegex(@"[a-z]")]
        private static partial Regex AtLeastOneLowerCaseLetter();
        [GeneratedRegex(@"\d")]
        private static partial Regex AtLeastOneDigit();
        [GeneratedRegex(@"[\W_]")]
        private static partial Regex AtLeastOneSpecialCharacter();
    }
}

