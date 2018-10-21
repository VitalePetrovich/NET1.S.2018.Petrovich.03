using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TasksDay03
{   
    /// <summary>
    /// The class contain FindNthRoot and FindNextBiggerNumber methods.
    /// </summary>
    public static class Day03
    {
        /// <summary>
        /// Calculate the nth root of a number by the Newton method.
        /// </summary>
        /// <param name="a">
        /// Number.
        /// </param>
        /// <param name="n">
        /// N of root.
        /// </param>
        /// <param name="precision">
        /// Calculation precision.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws, when trying calculate even root from a negative number, entered negative N of root or precision.
        /// </exception>>
        /// <returns>
        /// Answer.
        /// </returns>
        public static double FindNthRoot(double a, int n, double precision)
        {
            if (a < 0 && n % 2 == 0)
            {
                throw new ArgumentException("Can't calculate even root from a negative number");
            }

            if (n < 0)
            {
                throw new ArgumentException(nameof(n));
            }

            if (precision < 0)
            {
                throw new ArgumentException(nameof(precision));
            }

            double FindNthRootAlgo(double inputNumber, int nRoot, double targetPrecision)
            {
                double prec = inputNumber;
                double currResult = inputNumber;

                do
                {
                    double prevResult = currResult;
                    currResult = (1.0 / nRoot) 
                                 * ((nRoot - 1) * prevResult + inputNumber / Math.Pow(prevResult, nRoot - 1));
                    prec = Math.Abs(prevResult - currResult);
                }
                while (prec > targetPrecision);

                return Math.Round(currResult, precision.ToString().Length - 2);
            }

            return FindNthRootAlgo(a, n, precision);
        }

        /// <summary>
        /// Finds next bigger number from digits of the input number.
        /// </summary>
        /// <param name="inputNumber">
        /// Input number for calculating.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws, when entered negative number.
        /// </exception>>
        /// <returns>
        /// Next bigger number.
        /// </returns>
        public static int FindNextBiggerNumber(int inputNumber)
        {
            if (inputNumber < 0)
            {
                throw new ArgumentException(nameof(inputNumber));
            }

            int FindNextBiggerNumberAlgo(int input)
            {
                string inputString = input.ToString();
                int length = inputString.Length;

                for (int insertIndex = length - 2; insertIndex >= 0; insertIndex--)
                {
                    if (inputString[insertIndex] < inputString[insertIndex + 1])
                    {
                        char[] tempCharArray = inputString.Substring(insertIndex).ToCharArray();
                        Array.Sort(tempCharArray);

                        int indexNextBigger = tempCharArray.FindLast(inputString[insertIndex]) + 1;

                        MakeRightCharArray(tempCharArray, indexNextBigger);

                        if (length == tempCharArray.Length)
                        {
                            return Convert.ToInt32(new string(tempCharArray));
                        }
                        else
                        {
                            return Convert.ToInt32(inputString.Substring(0, length - 1 - indexNextBigger) + new string(tempCharArray));
                        }
                    }
                }

                return -1;
            }

            return FindNextBiggerNumberAlgo(inputNumber);
        }

        public static int FindLast(this char[] charArray, char value)
        {
            for (int currIndex = charArray.Length - 1; currIndex >= 0; currIndex--)
            {
                if (charArray[currIndex] == value)
                {
                    return currIndex;
                }
            }

            return -1;
        }

        public static void MakeRightCharArray(char[] charArray, int indexNextBigger)
        {
            char tempChar = charArray[indexNextBigger];
            for (int i = indexNextBigger; i > 0; i--)
            {
                charArray[i] = charArray[i - 1];
            }

            charArray[0] = tempChar;
        }
    }
}
