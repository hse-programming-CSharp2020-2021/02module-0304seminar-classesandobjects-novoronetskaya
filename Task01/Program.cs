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
        static void Main(string[] args)
        {
            RunTask01();
        }
        static void RunTask01()
        {
            double rMin = 0;
            double rMax = 0;
            double delta = 0;
            if (!GetValidData(ref rMin) || !GetValidData(ref rMax) || !GetValidData(ref delta))
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
        static bool GetValidData(ref double input)
        {
            if (!double.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine("Incorrect input");
                return false;
            }
            return true;
        }
    }
}
