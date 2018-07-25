using System;
using System.Linq;
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
 
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 68, 69, 15 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 7, 70, 17 }, ExpectedResult = new int[] { 7, 70, 17 })]
        [TestCase(new int[] { 7 }, ExpectedResult = new int[] { 7 })]
        [TestCase(new int[] { 10, 7, 2, 3, 7 }, ExpectedResult = new int[] { 7, 7 })]
        public int[] FilterDigit_ValidCases_ArrayOnlyWithDigit(int[] a) =>
            Algorithms.Filter(a, Algorithms.ContainsDigit).ToArray();

        [TestCase(null)]
        public void FilterDigit_NotValidCases(int[] a) =>
        Assert.Throws<ArgumentNullException>(() => Algorithms.Filter(a, Algorithms.ContainsDigit));

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

            a = Algorithms.Filter(a, Algorithms.ContainsDigit).ToArray();
            bool check = true;
            foreach (int i in a)
            {
                if (!Algorithms.ContainsDigit(i))
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
    }
}
