using System;
using ArraysStringsAlgorithms;
using NUnit.Framework;

namespace ArrayStringsAlgorithms.NUnitTests
{
    [TestFixture]
    public class AlgorithmTests
    {
        #region InsertNumberTests
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 3, ExpectedResult = 8)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public static int InsertNumber_ValidCases(int numberSource, int numberIn, int i, int j)
            => Algorithms.InsertNumber(numberSource, numberIn, i, j);

        [TestCase(15, 15, 8, 3)]
        [TestCase(15, 15, -5, 3)]
        [TestCase(15, 15, 8, 33)]
        public static void InsertNumber_NotValidIorJ_Exception(int numberSource, int numberIn, int i, int j) => 
            Assert.Throws<ArgumentException>(() => Algorithms.InsertNumber(numberSource, numberIn, i, j));
        #endregion

        #region FilterDigitsTests
        [TestCase(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(7, 1, 2, 3, 4, 5, 6, 68, 69, 15, ExpectedResult = new int[] { })]
        [TestCase(7, 7, 7, 70, 17, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(5, 5, ExpectedResult = new int[] { 5 })]
        [TestCase(5, 10, 5, 2, 3, 5, ExpectedResult = new int[] { 5, 5 })]
        public int[] FilterDigit_ValidCases_ArrayOnlyWithDigit(int digit, params int[] a) =>
            Algorithms.FilterDigit(digit, a);

        [TestCase(7)]
        public void FilterDigit_NotValidCases(int digit, params int[] a) =>
        Assert.Throws<ArgumentNullException>(() => Algorithms.FilterDigit(digit, a));

        [TestCase]
        public void FilterDigit_BigValueArray()
        {
            const int Length = int.MaxValue / 5000;
            int[] a = new int[Length];
            Random rnd = new Random();
            for (int i = 0; i < Length; i++)
            {
                a[i] = rnd.Next(-Length / 2, Length / 2);
            }

            a = Algorithms.FilterDigit(7, a);
            bool check = true;
            foreach (int i in a)
            {
                if (!ContainsDigit(i, 7))
                {
                    check = false;
                    break;
                }
            }

            Assert.IsTrue(check);
        }

        [TestCase]
        public void FilterDigit2_BigValueArray()
        {
            const int Length = int.MaxValue / 5000;
            int[] a = new int[Length];
            Random rnd = new Random();
            for (int i = 0; i < Length; i++)
            {
                a[i] = rnd.Next(-Length / 2, Length / 2);
            }

            a = Algorithms.FilterDigit2(7, a);
            bool check = true;
            foreach (int i in a)
            {
                if (!i.ToString().Contains("7"))
                {
                    check = false;
                    break;
                }
            }

            Assert.IsTrue(check);
        }
        #endregion

        private static bool ContainsDigit(int number, int digit)
        {
            int[] digits = ExtractDigits(number);
            for (int j = 0; j < digits.Length; j++)
            {
                if (digits[j] == digit)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] ExtractDigits(int number)
        {
            int[] digits = new int[] { };
            if (number < 0)
            {
                number *= -1;
            }

            while (number > 0)
            {
                Array.Resize(ref digits, digits.Length + 1);
                digits[digits.Length - 1] = number % 10;
                number /= 10;
            }

            return digits;
        }
    }
}
