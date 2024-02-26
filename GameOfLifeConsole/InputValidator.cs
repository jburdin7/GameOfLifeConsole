namespace GameOfLifeConsole
{
    class InputValidator
    {
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
