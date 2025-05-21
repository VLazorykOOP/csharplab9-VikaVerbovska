using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9Tasks
{
    public class Lab9T2
    {
        public void Run()
        {
            string inputFile = "numbers.txt";
            int a = 10, b = 50;

            Queue inRange = new Queue();
            Queue lessThanA = new Queue();
            Queue greaterThanB = new Queue();

            string[] parts = File.ReadAllText(inputFile, Encoding.UTF8).Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in parts)
            {
                if (int.TryParse(s, out int num))
                {
                    if (num >= a && num <= b)
                        inRange.Enqueue(num);
                    else if (num < a)
                        lessThanA.Enqueue(num);
                    else
                        greaterThanB.Enqueue(num);
                }
            }

            Console.WriteLine($"Інтервал [{a}; {b}]:");
            PrintQueue(inRange);

            Console.WriteLine($"\nМенше {a}:");
            PrintQueue(lessThanA);

            Console.WriteLine($"\nБільше {b}:");
            PrintQueue(greaterThanB);
        }

        private void PrintQueue(Queue q)
        {
            while (q.Count > 0)
                Console.Write(q.Dequeue() + " ");
            Console.WriteLine();
        }
    }
}
