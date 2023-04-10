using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCombine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfWord = 1;
            Console.Write("Введите свою строку: ");
            string word = Console.ReadLine();
            byte[] array = Encoding.Default.GetBytes(word.ToCharArray());
            array = array.OrderBy(x => x).ToArray();
            Console.WriteLine(Encoding.Default.GetString(array));
            PrintResult(array, ref amountOfWord);
            Console.WriteLine("Всего вариантов = " + amountOfWord);
            Console.ReadLine();
        }
        static void PrintResult(byte[] array, ref int amountOfWord)
        {
            
            while (true)
            {
                int i = NarayanaNextPerm(array);
                if (i == 0) break;
                Console.WriteLine(Encoding.Default.GetString(array));
                amountOfWord++;
            }
        }
        
        static int NarayanaNextPerm(byte[] a)
        {
            int i, k, t;
            byte tmp;
            int n = a.Length;
            for (k = n - 2; (k >= 0) && (a[k] >= a[k + 1]); k--) ;
            if (k == -1)
                return 0;
            for (t = n - 1; (a[k] >= a[t]) && (t >= k + 1); t--) ;
            tmp = a[k]; a[k] = a[t]; a[t] = tmp;
            for (i = k + 1; i <= (n + k) / 2; i++)
            {
                t = n + k - i;
                tmp = a[i]; a[i] = a[t]; a[t] = tmp;
            }
            return i;
        }
    }
}