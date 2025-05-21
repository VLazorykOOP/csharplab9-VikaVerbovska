using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9Tasks
{
    public class Lab9T1
    {
        public void Run()
        {
            string inputFile = "text1.txt";
            string text = "Це приклад тексту для аналізу голосних букв.";

            // Створюємо текстовий файл
            File.WriteAllText(inputFile, text, Encoding.UTF8);

            Stack vowels = new Stack();
            string vowelLetters = "аеєиіїоуюяАЕЄИІЇОУЮЯ";

            string fileContent = File.ReadAllText(inputFile, Encoding.UTF8);

            // Знаходимо голосні і заносимо їх у стек
            foreach (char c in fileContent)
            {
                if (vowelLetters.Contains(c))
                    vowels.Push(c);
            }

            Console.WriteLine("Голосні у зворотному порядку:");
            while (vowels.Count > 0)
            {
                Console.Write(vowels.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
