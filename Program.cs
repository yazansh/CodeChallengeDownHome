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
            string[] input = File.ReadAllLines(@"C:\\Users\\Msys\\Desktop\\Downhome Code Challenge\\Input.txt"); // reads all input string lines from Input.txt
            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int[] asciiNumbers = SortString(input[i]); // this method returns a sorted integer array of Ascii Code for each character in string
                output[i] = ConvertToString(asciiNumbers); // convert integer array to string and add the string to Output Array of strings
            }

            File.WriteAllLines(@"C:\\Users\\Msys\\Desktop\\Downhome Code Challenge\\my-outupt.txt",output); // writes the output to my-outpu.txt
            
            Console.ReadLine();
        }
        

        public static string ConvertToString(int[] array)
        {
            string line = "";
            for (int i = 0; i < array.Length; i++)
                line+=((char)array[i]);
            return line;
        }

        private static int[] SortString(string input)
        {
            int[] asciiNumbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
                asciiNumbers[i] = input[i];

            PartialSort(asciiNumbers);

            return asciiNumbers;
        }

        public static void PartialSort(int[] array)
        {
            Array.Sort(array);
        }

    }
}
