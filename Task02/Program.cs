/** Задание 2
 * 
 * Определить класс LatinChar с полем _char и свойством доступа к нему, значение поля – символ латинского алфавита. 
 * Значение поля по умолчанию – ‘a’. Определить конструкторы класса. 
 * 
 * В основной программе создать объект типа LatinChar и, 
 * последовательно перебирая все символы из заданного пользователем диапазона [minChar,  maxChar],  
 * выводить значение поля _char объекта.
 * 
 * Если введены некорректные данные, требуется вывести строку: "Incorrect input"
 * 
 * Пример входных данных: 
 * a f
 * 
 * Пример выходных данных:
 * a
 * b
 * c
 * d
 * e
 * f
 **/

using System;

namespace Task02
{
    class LatinChar
    {
        public char _char;
        public LatinChar() : this('a')
        {
        }
        public LatinChar(char symbol)
        {
            _char = symbol;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTask02();
        }
        static void RunTask02()
        {
            // TODO: ввод и обработка пользовательского ввода.
            string[] chars = Console.ReadLine().Split(' ');
            if (chars.Length != 2)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            char minChar = 'a';
            char maxChar = 'a';
            if (!GetValidData(ref minChar, chars[0]) || !GetValidData(ref maxChar, chars[1]))
            {
                return;
            }
            if (minChar > maxChar)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            while (minChar <= maxChar)
            {
                LatinChar latinChar = new LatinChar(minChar);
                Console.WriteLine(latinChar._char);
                minChar = (char)(minChar + 1);
            }
        }
        static bool GetValidData(ref char symbol, string input)
        {
            if (!char.TryParse(input, out symbol))
            {
                Console.WriteLine("Incorrect input");
                return false;
            }
            return true;
        }
    }
}
