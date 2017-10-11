namespace Week2.RomanNumerals
{
    using System;
    using System.Collections.Generic;

    public class RomanNumeralsConverter
    {
        private static readonly Dictionary<int, string> ArabicNumeralsToRomanNumerals = new Dictionary<int, string>()
        {
            {1000, "M" },
            {900, "CM" },
            {500, "D" },
            {400, "CD" },
            {100, "C" },
            {90, "XC" },
            {50, "L" },
            {40, "XL" },
            {10, "X" },
            {9, "IX" },
            {5, "V" },
            {4, "IV" },
            {1, "I" }
        };

        public string Convert(int arabicNumber)
        {
            var romanNumeralEnumerator = ArabicNumeralsToRomanNumerals.GetEnumerator();

            int remainingArabicNumberValue = arabicNumber;

            string romanNumber = String.Empty;

            while (romanNumeralEnumerator.MoveNext())
            {
                var currentRomanNumeral = romanNumeralEnumerator.Current;

                while (remainingArabicNumberValue >= currentRomanNumeral.Key)
                {
                    remainingArabicNumberValue -= currentRomanNumeral.Key;

                    romanNumber += currentRomanNumeral.Value;
                }
            }

            romanNumeralEnumerator.Dispose();

            return romanNumber;
        }
    }
}