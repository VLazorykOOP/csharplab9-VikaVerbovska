using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9Tasks
{
    public class Lab9T3_1 : ICloneable, IEnumerable
    {
        private ArrayList vowels = new ArrayList();
        private string vowelLetters = "аеєиіїоуюяАЕЄИІЇОУЮЯ";

        public void Run()
        {
            string inputFile = "text1.txt";
            File.WriteAllText(inputFile, "Це приклад тексту для аналізу голосних букв.", Encoding.UTF8);

            string content = File.ReadAllText(inputFile, Encoding.UTF8);
            foreach (char c in content)
            {
                if (vowelLetters.Contains(c))
                    vowels.Add(c);
            }

            Console.WriteLine("Голосні у зворотному порядку (ArrayList):");
            for (int i = vowels.Count - 1; i >= 0; i--)
                Console.Write(vowels[i] + " ");
            Console.WriteLine();
        }

        public object Clone()
        {
            Lab9T3_1 clone = new Lab9T3_1();
            clone.vowels = (ArrayList)this.vowels.Clone();
            return clone;
        }

        public IEnumerator GetEnumerator()
        {
            return vowels.GetEnumerator();
        }
    }
}
