using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.FizzBuzz
{
    public class FizzBuzzLogic
    {
        private const string FizzText = "Fizz";

        private const string BuzzText = "Buzz";

        private const string FizzBuzzText = "FizzBuzz";

        public string[] GetFizzBuzz()
        {
            var fizzBuzzValues = new string[100];

            for (int i = 0; i < 100; i++)
            {
                fizzBuzzValues[i] =  CalculateFizzBuzzValue(i);
            }
           
            return fizzBuzzValues;
        }

        private string CalculateFizzBuzzValue(int indice)
        {
            var outputValue = indice + 1;

            if (outputValue % 15 == 0)
            {
                return FizzBuzzText;
            }

            if (outputValue % 5 == 0)
            {
                return BuzzText;
            }

            if (outputValue % 3 == 0)
            {
                return FizzText;
            }

            return outputValue.ToString();
        }
    }
}
