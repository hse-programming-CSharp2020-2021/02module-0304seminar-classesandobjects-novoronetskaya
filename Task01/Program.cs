/** Задание 1
 * 
 * Определить класс Circle с полем радиус _r и свойством доступа к нему, значение радиуса - положительное вещественное число. 
 * В классе Circle описать конструктор без параметров и конструктор с вещественным параметром - радиусом круга.
 * Определить свойство S – площадь круга заданного радиуса. 
 * 
 * В основной программе получить от пользователя диапазон изменения значения радиуса: 
 * [rMin, rMax), rMin, rMax – произвольные вещественные числа и величину шага delta (delta > 0) разбиения данного диапазона. 
 * Создать объект типа Circle, затем последовательно изменяя значение радиуса на delta
 * вычислять и выводить на экран значение площади круга, ограниченного данной окружностью, с двумя знаками после запятой.
 * 
 * Если введены некорректные данные (в том числе данные, не являющиеся числами), требуется вывести строку: "Incorrect input"
 * 
 * Пример входных данных: 
 * 5 7 0.5
 * 
 * Пример выходных данных:
 * 78,54
 * 95,03
 * 113,10
 * 132,73
**/

using System;

namespace Task01
{
    class Circle
    {
        private double _r;
        public Circle()
        {
        }
        public Circle(double r)
        {
            _r = r;
        }
        public double R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
            }
        }
        public double S
        {
            get
            {
                return Math.PI * R * R;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            RunTask01();
        }
        static void RunTask01()
        {
            string[] numbers = Console.ReadLine().Split(' ');
            if (numbers.Length != 3)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            double rMin = 0;
            double rMax = 0;
            double delta = 0;
            if (!GetValidData(ref rMin, numbers[0]) || !GetValidData(ref rMax, numbers[1]) || !GetValidData(ref delta, numbers[2]))
            {
                return;
            }
            while (rMax - rMin > Double.Epsilon)
            {
                Circle circle = new Circle(rMin);
                Console.WriteLine($"{circle.S:f2}");
                rMin += delta;
            }
        }
        static bool GetValidData(ref double result, string input)
        {
            if (!double.TryParse(input, out result) || result <= 0)
            {
                Console.WriteLine("Incorrect input");
                return false;
            }
            return true;
        }
    }
}
