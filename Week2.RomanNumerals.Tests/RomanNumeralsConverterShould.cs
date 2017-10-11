namespace Week2.RomanNumerals.Tests
{
    using NUnit.Framework;
    using RomanNumerals;

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
        [TestCase(30, "XXX")]
        [TestCase(35, "XXXV")]
        [TestCase(39, "XXXIX")]
        [TestCase(40, "XL")]
        [TestCase(44, "XLIV")]
        [TestCase(50, "L")]
        [TestCase(51, "LI")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(846, "DCCCXLVI")]
        [TestCase(999, "CMXCIX")]
        [TestCase(1999, "MCMXCIX")]
        [TestCase(2008, "MMVIII")]
        public void ReturnARomanNumeralGivenAnArabicNumeral(int arabicNumeral, string expectedOutput)
        {
            var result = new RomanNumeralsConverter().Convert(arabicNumeral);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}
