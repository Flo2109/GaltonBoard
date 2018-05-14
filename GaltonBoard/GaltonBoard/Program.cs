using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GaltonBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = new int[32];
            for (int i = 0; i < 10_000_000; i++)
            {
                int n = random.Next(int.MaxValue);
                int bitCount = NumberOfSetBits(n);
                arr[bitCount]++;
            }

            PlotToConsole(arr);

            OpenInNotepad(arr);

            Console.ReadLine();
        }

        //https://stackoverflow.com/a/12175897
        static int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        private static void OpenInNotepad(int[] arr)
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (int i in arr)
                    sw.WriteLine(i);
            }

            Process.Start("notepad.exe", "output.txt");
        }

        private static void PlotToConsole(int[] arr)
        {
            int max = arr.Max();
            const int MaxColumns = 100;
            foreach (int i in arr)
            {
                int columns = i * MaxColumns / max;
                Console.WriteLine(new string('#', columns));
            }
        }
    }
}
