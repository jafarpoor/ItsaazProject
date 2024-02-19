namespace Common.Number
{
        public static class ConvertArabicNumberToEnglish
        {
            public static string ToEnglishNumber(string input)
            {
                string EnglishNumbers = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        EnglishNumbers += char.GetNumericValue(input, i);
                    }
                    else
                    {
                        EnglishNumbers += input[i].ToString();
                    }
                }
                return EnglishNumbers;
            }
        }
}
