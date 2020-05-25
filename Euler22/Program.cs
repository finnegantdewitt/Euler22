using System;
using System.Linq;

namespace Euler22
{
    class Program
    {
        static void Main(string[] args)
        {
            //parse names
            string namesRaw = System.IO.File.ReadAllText(@"C:\Users\finne\source\repos\Euler22\Euler22\names.txt");
            string[] names = namesRaw.Split(',');
            names = names.Select(name => name.Replace("\"", "")).ToArray();

            //easy way to sort names
            //Array.Sort(names, StringComparer.CurrentCulture);

            //custom quicksort way to sort names
            QuicksortNames(names, 0, names.Length - 1);

            NameRank(names);
        }

        static void NameRank(string[] names)
        {
            int nameScoreTotal = 0;
            for(int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                int namePos = i + 1;
                int nameCharSum = 0;
                foreach (char c in name)
                {
                    nameCharSum += c - 64;
                }
                int nameScore = nameCharSum * namePos;
                nameScoreTotal += nameScore;
            }
            Console.WriteLine(nameScoreTotal);
        }

        
        static void QuicksortNames(string[] names, int low, int high)
        {
            if(low < high)
            {
                int pi = Partition(names, low, high);
                QuicksortNames(names, low, pi - 1);
                QuicksortNames(names, pi + 1, high);
            }
        }
        static int Partition(string[] names, int low, int high)
        {
            string pivot = names[high];

            int i = (low - 1);
            for(int j = low; j <= high-1; j++)
            {
                //if the current element is smaller than the pivot
                if(names[j].CompareTo(pivot) == -1)
                {
                    i++; //increment index of smaller element
                    Swap(names, i, j);
                }
            }
            Swap(names, i + 1, high);
            return (i + 1);
        }
        static void Swap(string[] names, int x, int y)
        {
            string tmp = names[x];
            names[x] = names[y];
            names[y] = tmp;
        }
        static void PrintNames(string[] names)
        {
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
