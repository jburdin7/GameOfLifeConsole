namespace GameOfLifeConsole
{
    class InputValidator
    {
        private string[] ValidChoices { get; set; }

        public InputValidator(string[] validChoices)
        {
            this.ValidChoices = validChoices;
        }

        public bool ValidateString(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if(IsValidString(input, ValidChoices))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidString(string input, string[] validChoices)
        {
            return validChoices.Contains(input.ToLower());
        }
    }
}
