using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraysStringsAlgorithms.Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ILessThanJ_Exception() => Algorithms.InsertNumber(15, 15, 8, 3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_IOrJIsOutOfRange_Exception() => Algorithms.InsertNumber(15, 15, 33, -5);

        [TestMethod]
        public void InsertNumber_NullPositionsEqualNumbers_InsertToNullPosOneBit()
        {
            Assert.AreEqual(Algorithms.InsertNumber(15, 15, 0, 0), 15);
        }

        [TestMethod]
        public void InsertNumber_NullPositionsDifferentNumbers_InsertToNullPosOneBit()
        {
            Assert.AreEqual(Algorithms.InsertNumber(8, 15, 0, 0), 9);
        }

        [TestMethod]
        public void InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosEqualPos()
        {
            Assert.AreEqual(Algorithms.InsertNumber(8, 15, 3, 3), 8);
        }

        [TestMethod]
        public void InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosDifferentPos()
        {
            Assert.AreEqual(Algorithms.InsertNumber(8, 15, 3, 8), 120);
        }

        [TestMethod]
        public void FilterDigit_RandomArrayWithDigit_ArrayOnlyWithDigit()
        {
            int[] expected = { 7, 7, 70, 17 };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17));
        }

        [TestMethod]
        public void FilterDigit_RandomArrayWoutDigit_EmptyArray()
        {       
            int[] expected = { };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 1, 2, 3, 4, 5, 6, 68, 69, 15));
        }

        [TestMethod]
        public void FilterDigit_ArrayOnlyWithDigit_UnchangedArray()
        {
            int[] expected = { 7, 7, 70, 17 };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 7, 7, 70, 17));
        }

        [TestMethod]
        public void FilterDigit_BigValueArray()
        {
            const int Length = int.MaxValue / 10000;
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

        [TestMethod]
        public void FilterDigit2_BigValueArray()
        {
            const int Length = int.MaxValue / 10000;
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
