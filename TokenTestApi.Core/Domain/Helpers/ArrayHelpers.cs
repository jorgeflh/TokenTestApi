using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokenTestApi.Core.Domain.Helpers
{
    public static class ArrayHelpers
    {
        public static int[] GetFromAbsoluteDiff(int[] rawToken)
        {            
            var minNumber = rawToken.Min();
            var myList = new List<int>();

            for (var i = 0; i < rawToken.Length; i++)
            {
                if (Math.Abs(minNumber - rawToken[i]) <= 4)
                {
                    myList.Add(rawToken[i]);
                }
            }

            return myList.ToArray();
        }

        public static int[] RightRotate(int[] items, int rotate)
        {
            int[] result = new int[items.Length];

            for (var x = 0; x < rotate; x++)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    result[i] = items[(i + 1) % items.Length];
                }
            }

            return result;
        }
    }
}
