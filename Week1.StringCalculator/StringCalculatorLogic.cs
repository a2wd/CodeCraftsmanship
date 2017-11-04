namespace Week1.StringCalculator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class StringCalculatorLogic
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var outputNumbersAsString = numbers.Replace("\n", "").Split(',');

            int[] outputNumbers = new int[outputNumbersAsString.Length];

            for (int i = 0; i < outputNumbers.Length; i++)
            {
                if (int.TryParse(outputNumbersAsString[i], out outputNumbers[i]) == false)
                {
                    throw new InvalidInputException();
                }
            }

            return outputNumbers.Sum();
        }
    }
}
