using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursiveProgrammingSample.UnivercitySample.subtractionHumanAproach
{
    public class subtractionRecursive : IsubtractionHumanAproach
    {
        private static void Sub(int[,] Array, int[] calculated, int i, int j)  //recursive  subtraction
        {
            if (Array[i, j] >= Array[i + 1, j])
            {

                calculated[j] = Array[i, j] - Array[i + 1, j];
            }
            else
            {

                if (Array[i, j - 1] != 0)
                {

                    Array[i, j] += 10;
                    Array[i, j - 1] -= 1;

                    Sub(Array, calculated, i, j);
                    j--;
                }
                else if (Array[i, j - 1] == 0)
                {
                    Sub(Array, calculated, i, j);
                }

            }
        }
        public int[] Calculate(int[,] array)  //row first in array is first number and row second is second number
        {
            int y = array.GetLength(1);

            int[] result = new int[y];


            int i = 0;
            for (int j = y - 1; j >= 0; j--) //y column
            {
                Sub(array, result, i, j);
            }
            return result;
        }
    }
}
