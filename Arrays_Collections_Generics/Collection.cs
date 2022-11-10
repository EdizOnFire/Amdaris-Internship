using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Collections_Generics
{
    public class Collection
    {
        public static string AnswerFromConsole(string request)
        {
            Console.Write(request);
            return Console.ReadLine();
        }

        public static void GetItem<Thing>(Thing[] array)
        {
            int index = int.Parse(AnswerFromConsole("Enter the index for the item you want to get: "));
            Console.WriteLine($"{array[index]} is at index {index}.");
        }

        public static void SetItem<Thing>(Thing[] array, Thing item)
        {
            int index = int.Parse(AnswerFromConsole("Enter the index for the item you want to set: "));
            array[index] = item;
            Console.WriteLine("Modified array:");
            foreach (var thing in array)
            {
                Console.Write(thing + " ");
            }

            Console.WriteLine();
        }

        public static void SwapItems<Thing>(Thing[] array)
        {
            int index = int.Parse(AnswerFromConsole("Enter the index for the first item you want to swap: "));
            int index2 = int.Parse(AnswerFromConsole("Enter the index for the second item you want to swap: "));
            Thing temp = array[index];
            array[index] = array[index2];
            array[index2] = temp;
            Console.WriteLine("Modified array:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
