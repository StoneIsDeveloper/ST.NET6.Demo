using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTest
{
    public class CenterUility
    {
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
    }
}
