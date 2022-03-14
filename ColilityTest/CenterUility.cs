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
            var str = number.ToString("N");

            var findOne = false;
            var maxGap = 0;
            var zeroCount = 0;
            var divResult = number;

            while (divResult > 0)
            {
                var remainder = 0;
                divResult = Math.DivRem(divResult, 2, out remainder);  // 取整 & 取余
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



        public static int? OddOccurrencesInArray(int[] A)
        {
            var dictionary = new Dictionary<int, short>();
            int? oddVal = null;

            for(var i=0; i< A.Length; i++)
            {
                if (dictionary.ContainsKey(A[i]))
                {
                    dictionary[A[i]] = 2;
                }
                else
                {
                    dictionary.Add(A[i], 1);
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


        public static int FrogJmp(int X,int Y, int D)
        {
            int divRem = 0;

            var gap = Y - X;
            var divResult = Math.DivRem(gap, D, out divRem);
            if (divRem > 0)
                divResult++;

            return divResult;
        }
        public static int FrogJmpV2(int x, int y, int d)
        {
           return ((y-x)%d ==0) ? (y-x)/d : (y - x) / d + 1;  
        }

        public static int PermMissingElem(int[] A)
        {
            // empty and single
            
            if (A.Length == 0)
            {
                return 1;
            }                 
            if(A.Length == 1)
            {
                return 1;
            }

            var result = A[0] ^ 1; ;
            var missingElement = A[0] ^ 1;

            for(int i = 1; i< A.Length; i++)
            {
                missingElement = missingElement ^ A[i] ^ (i + 1);
            }
            result = missingElement ^ (A.Length + 1);

            return result;

        }

        public static int TapeEquilibrium(int[] A)
        {
            var miniGap = 0;

            for (int i = 0; i < A.Length; i++)
            {
                var leftSum = 0;
                for(int m = 0; m < i+1; m++)
                {
                    leftSum = leftSum + A[m];
                }

                var rightSum = 0;

                for (int k = A.Length-1; k > i; k--)
                {
                    rightSum = rightSum + A[k];
                }
              
                var diff = Math.Abs(leftSum - rightSum);
                if (i==0) miniGap = diff;
                
                miniGap = diff < miniGap ? diff : miniGap;
            }
            return miniGap;
        }

        // 100%
        public static int TapeEquilibriumV2(int[] A)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return 0;

            int sum = 0;
            var miniValue = int.MaxValue;
            foreach (var item in A)
            {
                sum += item;
            }
            int leftSum = 0;

            for (int i = 0; i < A.Length-1; i++)
            {
                leftSum += A[i];
                int currentDiff = Math.Abs((sum-leftSum) -leftSum);
                if(currentDiff < miniValue)
                {
                    miniValue = currentDiff;
                }
            }
            return miniValue;
        }


        #endregion

        #region Lesson 4 
       /// <summary>
       ///Performance: 66% 
       ///Correctness: 100%
       /// </summary>
       /// <param name="N"></param>
       /// <param name="A"></param>
       /// <returns></returns>
        public static int[] MaxCounters(int N, int[] A)
        {
            int[] result = new int[N];
            var length = A.Length;
            int max = 0;
            for (int i = 0;i < A.Length;i++)
            {
                var indexResult = A[i];
                var index = A[i] - 1;
                if (A[i] <= N && A[i] >=1)
                {
                    result[index]++;
                    if(result[index] > max)
                        max = result[index];  
                }
                else
                {
                    // find max value , and all set to max value
                    for(int k=0; k < result.Length; k++)
                    {
                        result[k] = max;
                    }
                }
            }
            return result;
        }

        public static int[] MaxCountersV2(int N, int[] A)
        {
            return A;
        }
        #endregion
    }
}
