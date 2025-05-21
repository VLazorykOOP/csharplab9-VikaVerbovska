using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9Tasks
{
    public class Lab9T3_2 : IEnumerable
    {
        private ArrayList allNumbers = new ArrayList();
        private int a = 10, b = 50;

        public void Run()
        {
            string inputFile = "numbers.txt";
            File.WriteAllText(inputFile, "8 23 4 60 12 51 30 9 75", Encoding.UTF8);

            string[] parts = File.ReadAllText(inputFile, Encoding.UTF8).Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in parts)
            {
                if (int.TryParse(s, out int num))
                    allNumbers.Add(num);
            }

            ArrayList inRange = new ArrayList();
            ArrayList less = new ArrayList();
            ArrayList greater = new ArrayList();

            foreach (int num in allNumbers)
            {
                if (num >= a && num <= b)
                    inRange.Add(num);
                else if (num < a)
                    less.Add(num);
                else
                    greater.Add(num);
            }

            Console.WriteLine($"Інтервал [{a}; {b}]:");
            PrintList(inRange);
            Console.WriteLine($"\nМенше {a}:");
            PrintList(less);
            Console.WriteLine($"\nБільше {b}:");
            PrintList(greater);
        }

        private void PrintList(ArrayList list)
        {
            foreach (int n in list)
                Console.Write(n + " ");
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            return allNumbers.GetEnumerator();
        }

        // Приклад IComparer — якщо треба буде сортувати (не обов'язково для цього завдання)
        public class NumberComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((int)x).CompareTo((int)y);
            }
        }
    }
}
