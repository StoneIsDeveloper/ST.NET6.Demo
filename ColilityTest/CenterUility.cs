﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTest
{
    public class CenterUility
    {
        #region Lesson 1 Iterations
        public static int FindMaxBinaryGap(int number)
        {
            {
                var number1 = 17;
                // 10000  16
                // 10001  17
                var n1 = number1 / 2;
                var n2 = number1 % 2;
            }

            var findOne = false;
            var maxGap = 0;
            var zeroCount = 0;
            var divResult = number;

            while (divResult > 0)
            {
                var remainder = 0;
                // divResult = Math.DivRem(divResult, 2, out remainder);  // 取整 & 取余
                divResult = divResult / 2; // 取整 & 取余
                remainder = divResult % 2; // 取整 & 取余
                if (remainder == 1)
                {
                    findOne = true;
                    zeroCount = 0;
                }
                else if (findOne)
                {
                    zeroCount++;
                    if (zeroCount > maxGap)
                        maxGap = zeroCount;
                }

            }

            return maxGap;
        }
        #endregion

        #region Lesson 2 Arrays
        public static int[] CyclicRotation(int[] a, int k)
        {
            var b = new int[a.Length];

            for(int i=0; i< a.Length; i++)
            {
                b[(i + k) % a.Length] = a[i];
            }

            return b;
        }



        public static int? OddOccurrencesInArray(int[] a)
        {
            var dictionary = new Dictionary<int, short>();
            int? oddVal = null;

            for(var i=0; i< a.Length; i++)
            {
                if (dictionary.ContainsKey(a[i]))
                {
                    dictionary[a[i]] = 2;
                }
                else
                {
                    dictionary.Add(a[i], 1);
                }
            }

            foreach (KeyValuePair<int, short> entry in dictionary)
            {
                if (entry.Value == 1)
                {
                    oddVal = entry.Key;
                    break;
                }
            }

            return oddVal;
        }
        #endregion

        #region Lesson 3 Time Complexity


        public static int FrogJmp(int x,int y, int d)
        {
            int divRem = 0;

            var gap = y - x;
            var divResult = Math.DivRem(gap, d, out divRem);
            if (divRem > 0)
                divResult++;

            return divResult;
        }
        public static int FrogJmpV2(int x, int y, int d)
        {
           return ((y-x)%d ==0) ? (y-x)/d : (y - x) / d + 1;  
        }

        public static int PermMissingElem(int[] a)
        {
            var result = a[0] ^ 1; ;
            var missingElement = a[0] ^ 1;

            for(int i = 1; i< a.Length; i++)
            {
                missingElement = missingElement ^ a[i] ^ (i + 1);
            }
            result = missingElement ^ (a.Length + 1);

            return result;

        }

        #endregion
    }
}
