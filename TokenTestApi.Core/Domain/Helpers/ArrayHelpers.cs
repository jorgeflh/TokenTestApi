using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokenTestApi.Core.Domain.Helpers
{
    public static class ArrayHelpers
    {
        public static int[] GetNumbersBasedOnAbsoluteDifference(int[] rawToken)
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
    }
}
