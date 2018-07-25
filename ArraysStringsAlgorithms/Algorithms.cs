using System;
using System.Collections.Generic;

namespace ArraysStringsAlgorithms
{  
    /// <summary>
    /// Class of algorithms
    /// </summary>
    public static class Algorithms
    {
        #region Insert API
        /// <summary>
        /// Number of the bits in int32 number
        /// </summary>
        private const int NumBits = 32;

        /// <summary>
        /// Inserting the section of number 
        /// </summary>
        /// <param name="numberSource">
        /// Source number
        /// </param>
        /// <param name="numberIn">
        /// Inserting number
        /// </param>
        /// <param name="i">
        /// The first position of the section
        /// </param>
        /// <param name="j">
        /// The second position of the section
        /// </param>
        /// <returns>
        /// Inserted number
        /// </returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            ValidIJ(i, j);            
            int temp = 0;
            temp = ~temp;
            temp = temp << (j - i + 1);
            temp = ~temp;

            numberIn = numberIn & temp;
            numberIn = numberIn << i;

            int numberOut = numberIn | numberSource;
            return numberOut;
        }
        #endregion

        #region Filter API        
        /// <summary>
        /// Filters by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Filtered Enumerable</returns>
        /// <exception cref="ArgumentNullException">a</exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> a, Func<T, bool> predicate) 
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            foreach (T i in a)
            {
                if (predicate(i))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Filter the array: leave only numbers w digit (string) 
        /// </summary>
        /// <param name="digit">
        /// the digit
        /// </param>
        /// <param name="a">
        /// The array
        /// </param>
        /// <returns>
        /// Filtered array
        /// </returns>
        public static int[] FilterDigit2(int digit, params int[] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentNullException(nameof(a));
            }

            int resultLength = 0;
            foreach (int i in a)
            {
                if (i.ToString().Contains(digit.ToString()))
                {
                    resultLength++;
                }
            }

            int[] result = new int[resultLength];
            int pos = 0;
            foreach (int i in a)
            {
                if (i.ToString().Contains(digit.ToString()))
                {
                    result[pos++] = i;
                }
            }

            return result;
        }
        #endregion

        #region Private Insert
        /// <summary>
        /// Validation of the edges of the section
        /// </summary>
        /// <param name="i">
        /// the first edge
        /// </param>
        /// <param name="j">
        /// the second edge
        /// </param>
        private static void ValidIJ(int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("J parametr should be bigger than I");
            }

            if (i < 0 || j < 0 || i > NumBits - 1 || j > NumBits - 1)
            {
                throw new ArgumentException("I or J parametrs should be from 0 to 31");
            }
        }
        #endregion

        #region Filtering by the digit 7
        /// <summary>
        /// Checks containing digit in the number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="digit">
        /// The digit
        /// </param>
        /// <returns>
        /// True if contains
        /// </returns>
        public static bool ContainsDigit(this int number)
        {
            int digit = 7;
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

        /// <summary>
        /// Extract digits from number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// The digits
        /// </returns>
        public static int[] ExtractDigits(int number)
        {
            if (number < 0)
            {
                number *= -1;
            }

            int[] digits = new int[(int)Math.Log10(number) + 1];
            int temp = number;
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = temp % 10;
                temp /= 10;
            }

            return digits;
        }
        #endregion
    }
}
