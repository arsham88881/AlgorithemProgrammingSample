using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursiveProgrammingSample.UnivercitySample.subtractionHumanAproach
{
    public class subtractionSimple : IsubtractionHumanAproach
    {
        public int[] Calculate(int[,] array) //row first in array is first number and row second is second number
        {
            int y = array.GetLength(1);

            int[] result = new int[y];

            int i = 0;
            for (int j = y - 1; j >= 0; j--) //y column
            {
                if (array[i, j] == array[i + 1, j])
                {
                    result[j] = 0;
                }
                else if (array[i, j] > array[i + 1, j])
                {

                    result[j] = array[i, j] - array[i + 1, j];
                }
                else if (array[i, j] < array[i + 1, j])
                {
                    if (array[i, j - 1] != 0)
                    {
                        array[i, j] += 10;
                        array[i, j - 1] -= 1;

                        result[j] = array[i, j] - array[i + 1, j];
                    }
                    else if (array[i, j - 1] == 0)
                    {
                        if (array[i, j - 2] != 0)
                        {
                            array[i, j] = (array[i, j - 2] - 1) - 1;
                            array[i, j - 2] -= 1;
                            array[i, j - 1] += array[i, j - 2] - 1;

                            result[i] = array[i, j] - array[i + 1, j];
                        }
                        else if (array[i, j - 2] == 0)
                        {
                            if (array[i, j - 3] != 0)
                            {
                                array[i, j] = ((array[i, j - 2] - 1) - 1) - 1;
                                array[i, j - 3] -= 1;
                                array[i, j - 2] += array[i, j - 3] - 1;
                                array[i, j - 1] += array[i, j - 2] - 1;

                                result[j] = array[i, j] - array[i + 1, j];
                            }
                            else if (array[i, j - 3] == 0)
                            {
                                if (array[i, j - 4] != 0)
                                {
                                    array[i, j] = (((array[i, j - 2] - 1) - 1) - 1) - 1;
                                    array[i, j - 4] -= 1;
                                    array[i, j - 3] += array[i, j - 4] - 1;
                                    array[i, j - 2] += array[i, j - 3] - 1;
                                    array[i, j - 1] += array[i, j - 2] - 1;

                                    result[j] = array[i, j] - array[i + 1, j];
                                }
                                else if (array[i, j - 4] == 0)
                                {
                                    if (array[i, j - 5] != 0)
                                    {
                                        array[i, j] = ((((array[i, j - 2] - 1) - 1) - 1) - 1) - 1;
                                        array[i, j - 5] -= 1;
                                        array[i, j - 4] += array[i, j - 5] - 1;
                                        array[i, j - 3] += array[i, j - 4] - 1;
                                        array[i, j - 2] += array[i, j - 3] - 1;
                                        array[i, j - 1] += array[i, j - 2] - 1;

                                        result[i] = array[i, j] - array[i + 1, j];
                                    }
                                }
                            }

                        }

                    }
                }
            }
            return result;
        }
    }
}
