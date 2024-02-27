
namespace GameOfLifeConsole
{
    class InputValidator
    {
        public bool ValidateNumber(string input, ref int number)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out number))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateString(string input, string[] validChoices)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if(IsValidString(input, validChoices))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidString(string input, string[] validChoices)
        {
            return validChoices.Contains(input);
        }
    }
}
