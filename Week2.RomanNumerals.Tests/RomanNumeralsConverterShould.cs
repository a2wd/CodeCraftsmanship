using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Week2.RomanNumerals.Tests
{
    [TestFixture]
    public class RomanNumeralsConverterShould
    {
        [Test]
        public void ReturnAStringGivenAPositiveInteger()
        {
            var result = new RomanNumeralsConverter().Convert(1);

            Assert.That(result.GetType(),Is.EqualTo(typeof(string)));
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(17, "XVII")]
        [TestCase(18, "XVIII")]
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(40, "XL")]
        public void ReturnARomanNumeralGivenAnArabicNumeral(int arabicNumeral, string expectedOutput)
        {
            var result = new RomanNumeralsConverter().Convert(arabicNumeral);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }

    public class RomanNumeralsConverter
    {
        private static readonly Dictionary<int, string> ArabicNumeralsToRomanNumerals = new Dictionary<int, string>()
        {
            {1, "I" },
            {4, "IV" },
            {5, "V" },
            {9, "IX" },
            {10, "X" },
            {40, "XL" }
        };

        public string Convert(int arabicNumber)
        {
            if (ArabicNumeralsToRomanNumerals.ContainsKey(arabicNumber))
            {
                return ArabicNumeralsToRomanNumerals[arabicNumber];
            }

            if (arabicNumber > 10)
            {
                return ArabicNumeralsToRomanNumerals[10] + Convert(arabicNumber - 10);
            }

            if (arabicNumber > 5)
            {
               return ArabicNumeralsToRomanNumerals[5] + Convert(arabicNumber - 5);
            }
            
            return ArabicNumeralsToRomanNumerals[1] + Convert(arabicNumber - 1);
        }
    }
}
