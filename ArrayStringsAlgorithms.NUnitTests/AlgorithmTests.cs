using NUnit.Framework;
using ArraysStringsAlgorithms;
using System;
using System.Collections;

namespace ArrayStringsAlgorithms.NUnitTests
{
    [TestFixture]
    class AlgorithmTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        public static int InsertNumber_NullPositionsEqualNumbers_InsertToNullPosOneBit(int numberSource, int numberIn, int i, int j)
            => Algorithms.InsertNumber(15, 15, 0, 0);

        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        public static int InsertNumber_NullPositionsDifferentNumbers_InsertToNullPosOneBit(int numberSource, int numberIn, int i, int j)
            => Algorithms.InsertNumber(8, 15, 0, 0);

        [TestCase(8, 15, 3, 3, ExpectedResult = 8)]
        public static int InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosEqualPos(int numberSource, int numberIn, int i, int j)
        => Algorithms.InsertNumber(8, 15, 3, 3);

            [TestCase(8, 15, 3, 3, ExpectedResult = 120)]
        public static int InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosDifferentPos(int numberSource, int numberIn, int i, int j)
        => Algorithms.InsertNumber(8, 15, 3, 8);

        [Test]
        public void InsertNumber_ILessThanJ_Exception() => 
            Assert.Throws<ArgumentException>(() => Algorithms.InsertNumber(15, 15, 8, 3));
        [Test]
        public void InsertNumber_IOrJIsOutOfRange_Exception() =>
           Assert.Throws<ArgumentException>(() => Algorithms.InsertNumber(15, 15, -5, 33));

        [TestCase(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        public int[] FilterDigit_RandomArrayWithDigit_ArrayOnlyWithDigit(int digit, params int[] a) =>
            Algorithms.FilterDigit(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);

        [TestCase(7, 1, 2, 3, 4, 5, 6, 68, 69, 15, ExpectedResult = new int[] {  })]
        public int[] FilterDigit_RandomArrayWoutDigit_EmptyArray(int digit, params int[] a) =>
            Algorithms.FilterDigit(7, 1, 2, 3, 4, 5, 6, 68, 69, 15);

        [TestCase(7, 7, 7, 70, 17, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        public int[] FilterDigit_ArrayOnlyWithDigit_UnchangedArray(int digit, params int[] a) =>
            Algorithms.FilterDigit(7, 7, 7, 70, 17);

    }
}
