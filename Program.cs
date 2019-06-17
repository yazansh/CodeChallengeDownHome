using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownHomeCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pleae enter the path of the folder that contains Input.txt file");
            String path = Console.ReadLine();

            string[] input = File.ReadAllLines(@path+"\\Input.txt"); // reads all input string lines from Input.txt
            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int[] asciiNumbers = SortString(input[i]); // this method returns a sorted integer array of Ascii Code for each character in string
                output[i] = ConvertToString(asciiNumbers); // convert integer array to string and add the string to Output Array of strings
            }

            File.WriteAllLines(path+"\\my-outupt.txt",output); // writes the output to my-outpu.txt
            
            Console.ReadLine();
        }
        

        public static string ConvertToString(int[] array)
        {
            string line = "";
            for (int i = 0; i < array.Length; i++)
                line+=((char)array[i]);
            return line;
        }

        public static bool IsDigit(int c)
        {
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        /* This method detects every partition/sequence then calls the partialSort method to sort this certain sequence.
         * it checks every char whether it is a digit or not using the IsDigit method.
         * used (leftIndex) and (rightIndex) to detect sequence limits.
         * */
        private static int[] SortString(string input)
        {
            int[] asciiNumbers = new int[input.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            bool lastCharType = IsDigit(input[0]); // if char is digit it will have the value "True" else the value is "False".
            asciiNumbers[0] = input[0];
            bool currentCharType = false;

            for (int i = 1; i < input.Length; i++)
            {
                asciiNumbers[i] = input[i];
                currentCharType = IsDigit(asciiNumbers[i]);

                if (currentCharType != lastCharType)
                {
                    PartialSort(asciiNumbers, leftIndex, rightIndex);
                    leftIndex = i;
                }

                rightIndex = i;
                lastCharType = currentCharType;
            }

            PartialSort(asciiNumbers, leftIndex, rightIndex);
            return asciiNumbers;
        }

        /* This method operates on the sequence sent by SortString method.
         * it sorts the sequence then assign the values back to the original array in the new order.
         */
        public static void PartialSort(int[] array, int leftIndex, int rightIndex)
        {
            int[] tempArray = new int[rightIndex - leftIndex + 1];
            for (int j = 0, i = leftIndex; i <= rightIndex; i++, j++)
                tempArray[j] = array[i];

            Array.Sort(tempArray);
            
            for (int j = 0, i = leftIndex; i <= rightIndex; i++, j++)
                array[i] = tempArray[j];

            return;
        }

    }
}
