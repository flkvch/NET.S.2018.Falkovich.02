using System;

namespace ArraysStringsAlgorithms
{  
    /// <summary>
    /// Class of algorithms
    /// </summary>
    public static class Algorithms
    {
        #region API
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

        /// <summary>
        /// Filter the array: leave only numbers w digit 
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
        public static int[] FilterDigit(int digit, params int[] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentNullException(nameof(a));
            }

            int[] temp = new int[] { };
            for (int i = 0; i < a.Length; i++)
            {
                if (ContainsDigit(a[i], digit))
                {                    
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = a[i];
                }
            }

            return temp;
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

            int[] temp = new int[] { };
            for (int i = 0; i < a.Length; i++)
            {
                string digits = a[i].ToString();
                if (digits.Contains(digit.ToString()))
                {
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = a[i];
                }
            }

            return temp;
        }
        #endregion

        #region Private
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

        /// <summary>
        /// Extract digits from number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// The digits
        /// </returns>
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
        #endregion
    }
}
