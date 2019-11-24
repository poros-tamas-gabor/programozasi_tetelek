using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programozasi_tetelek
{
    class Program
    {
        static void Main(string[] args)
        {
            int osszegzes(int[] tomb)
            {
                // tömb elemeinek összegzése - sum of elements in a given array
                int result = 0;
                for (int i = 0; i < tomb.Length; i++)
                {
                    result = result + tomb[i];
                }
                return result;
            }

            int megszamolas(int[] tomb)
            {
                // tömb elemeinek összegzése feltétel mellett - sum of elements in a given array with condition
                int result = 0;
                for(int i =0;i < tomb.Length; i++)
                {
                    //Feltétel minden pozitív szám, Condition: sum every positive number
                    if (tomb[i] > 0)
                    {
                        result = result + tomb[i];
                    }
                }
                return result;
            }

            bool eldontes(int[] tomb, int num)
            {
                // kérdéses számot tartalmazza-e a tömb - is the given number element of the array?
                bool result = false;
                int i = 0;
                while(i < tomb.Length && result == false)
                {
                    if (tomb[i] == num)
                    {
                        result = true;
                    }
                    i++;
                }
                return result;
            }

            Tuple<bool,int?>  kereses(int[] tomb, int num)
            {
                // input (vizsgált tömb, keresett szám) return (bool tartalmazza e a tömb a keresett számot, int? a keresett szám indexe)
                //- returns a tuple ((tuple.item1 true if the array contains the element, and false if not), (int? index of a value in an array))
                bool include_check = false;
                int? result_index = null;
                int i = 0;
                while (i < tomb.Length && include_check == false)
                {
                    if (tomb[i] == num)
                    {
                        include_check = true;
                        result_index = i;
                    }
                    i++;
                }
                Tuple<bool, int?> result = new Tuple<bool, int?>(include_check, result_index);
                return result;
            }

            int[] kivalogatas(int[]tomb, Func<int,bool> feltetel)
            // A tömb elemit egy másik tömbbe másolja, feltételhez kötve.
            // Conditional Copy the elements of the array to another array
            // input (int[] array, condition)
            // return (int[] array)
            {
                int[] result = new int[tomb.Length];
                int k = 0;
                for(int i = 0; i < tomb.Length; i++)
                {
                    if (feltetel(tomb[i]) == true) {
                        result[k] = tomb[i];
                        k++;
                    }
                }
                return result;
            }
            bool probafeltetel(int num)
            {
                bool result = (num > 5);
                return result;
            }
            List<int[]> szetvalogatas(int[] tomb, Func<int, bool> feltetel)
            // A tömb elemeit két tömbbe válogatja szét, feltételhez kötve.
            // conditional separation 
            // input (int[] array, condition)
            // return (List<int[]> list)
            {

                int[] result01 = new int[tomb.Length], result02 = new int[tomb.Length];
                int k = 0, j = 0;
                for (int i = 0; i < tomb.Length; i++)
                {
                    if (feltetel(tomb[i]) == true)
                    {
                        result01[k++] = tomb[i];
                    }
                    else
                    {
                        result02[j++] = tomb[i];
                    }
                }
                List<int[]> result = new List<int[]>() { result01, result02 };
                return result;
            }

            int[] metszet(int[] tomb01, int[] tomb02)
            {
                int n = 0;
                if (tomb01.Length > tomb02.Length) n = tomb01.Length;
                else n = tomb02.Length;
                int[] result = new int[n];
                int l = 0;
                for (int i = 0; i < tomb01.Length; i++)
                {
                    int k = 0, j = 0;
                    bool duplicate_check = false;
                    while(k < result.Length && duplicate_check == false)
                    {
                        if (result[k] == tomb01[i]) duplicate_check = true;
                        k++;
                    }
                    if (duplicate_check == false)
                    {
                        bool got_it = false;
                        while (j < tomb02.Length && got_it == false)
                        {
                            if (tomb02[j] == tomb01[i])
                            {
                                result[l] = tomb01[i];
                                got_it = true;
                                l++;
                            }
                            j++;
                        }
                    }
                }
                return result;
            }

            int[] unio(int[] tomb01, int[] tomb02)
            {
                int[] result = new int[tomb01.Length + tomb02.Length];
                int k = 0;
                for (int i = 0; i<tomb01.Length; i++)
                {
                    bool duplicate_check = false;
                    int j = 0;
                    while (j < result.Length && duplicate_check == false)
                    {
                        if (result[j] == tomb01[i])
                        {
                            duplicate_check = true;
                        }
                        j++;
                    }
                    if (duplicate_check == false)
                    {
                        result[k] = tomb01[i];
                        k++;
                    }
                }
                for (int j = 0; j < tomb02.Length; j++)
                {
                    bool duplicate_check = false;
                    int i= 0;
                    while (i < tomb01.Length && duplicate_check == false)
                    {
                        if (tomb02[j] == tomb01[i])
                        {
                            duplicate_check = true;
                        }
                        i++;
                    }
                    if (duplicate_check == false)
                    {
                        result[k] = tomb02[j];
                        k++;
                    }

                }
            
                return result;
            }
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8 ,-23,6,2,-76};
            int[] C = { 2, 2, 4, 5, 15, 85 ,6};
            var B = unio(A, C);
            foreach (var item in B)
            {

                Console.Write(item +" ");
            }
                
            Console.ReadLine();

        }
    }
}
