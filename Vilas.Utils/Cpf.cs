namespace Vilas.Utils.Text
{
    public static class Cpf
    {
        public static bool Validate(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.All(c => c == cpf[0]))
                return false;

            int firstChecksum = CalculateChecksum(cpf, 9, 10);
            if (firstChecksum != int.Parse(cpf[9].ToString()))
                return false;

            int secondChecksum = CalculateChecksum(cpf, 10, 11);
            if (secondChecksum != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private static int CalculateChecksum(string cpf, int length, int multiplier)
        {
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (multiplier - i);
            }
            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
