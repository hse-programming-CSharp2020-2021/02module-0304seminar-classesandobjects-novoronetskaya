/** Задание 3
 * 
 * Описать класс комплексных чисел Complex. Комплексные числа имеют вид a+bi, где i^2=-1, a, b - действительные числа. Определить в нем:
 * конструктор, принимающий действительную и мнимую часть;
 * свойства Re и Im, возвращающие действительную и мнимые части;
 * свойства Abs и Arg, возвращающие модуль и аргумент числа;
 * метод Add сложения комплексного числа с другим комплексным или действительным числом;
 * метод Subtract вычитания из комплексного числа другого комплексного или действительного числа.
 * метод Multiply умножения комплексного числа на другое комплексное или действительное число.
 * переопределенный ToString, возвращающий строку в формате "a+bi", где a, b выводятся с двумя знаками после запятой.
 * 
 * В основной программе считать последовательно два комплексных числа,
 * затем вывести их модули и аргументы, результаты сложения, вычитания и умножения введеных чисел.
 * 
 * Если введены некорректные данные (в том числе данные, не являющиеся числами), требуется вывести строку: "Incorrect input"
 * 
 * Пример входных данных:
 * 5 2
 * 1 3
 * 
 * Пример выходных данных:
 * 5,39 3,16
 * 0,38 1,25
 * 6,00+5,00i
 * 4,00-1,00i
 * -1,00+17,00i
 * 
 * Пояснение: на первой строке выходных данных расположены модули комплексных чисел, на второй - аргументы.
**/

using System;

namespace Task03
{
    class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public double Abs
        {
            get
            {
                return Math.Sqrt(Re * Re + Im * Im);
            }
        }
        public double Arg
        {
            get
            {
                if (Re < 0)
                {
                    return Math.Atan(Im / Re) + Math.PI;
                }
                return Math.Atan(Im / Re);
            }
        }
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public Complex Add(Complex number)
        {
            Complex sum = new Complex(Re + number.Re, Im + number.Im);
            return sum;
        }
        public Complex Subtract(Complex number)
        {
            Complex difference = new Complex(Re - number.Re, Im - number.Im);
            return difference;
        }
        public Complex Multiply(Complex number)
        {
            Complex result = new Complex(Re * number.Re - Im * number.Im, Re * number.Im + Im * number.Re);
            return result;
        }
        public override string ToString()
        {
            string result = String.Empty;
            if (Math.Round(Re, 2) != 0)
            {
                result = $"{Re:f2}";
            }
            if (Math.Round(Im, 2) != 0)
            {
                if (Im < 0)
                {
                    result += $"{Im:f2}i";
                }
                else
                {
                    result += $"+{Im:f2}i";
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTask03();
        }
        static void RunTask03()
        {
            // TODO: ввод и обработка пользовательского ввода.
            string[] data = Console.ReadLine().Split(' ');
            double im = 0;
            double re = 0;
            if (!GetValidData(ref re, data[0]) || !GetValidData(ref im, data[1]))
            {
                return;
            }
            Complex a = new Complex(re, im);
            data = Console.ReadLine().Split(' ');
            if (!GetValidData(ref re, data[0]) || !GetValidData(ref im, data[1]))
            {
                return;
            }
            Complex b = new Complex(re, im);
            Console.WriteLine($"{a.Abs:f2} {b.Abs:f2}");
            Console.WriteLine($"{a.Arg:f2} {b.Arg:f2}");
            Console.WriteLine(a.Add(b));
            Console.WriteLine(a.Subtract(b));
            Console.WriteLine(a.Multiply(b));
        }
        static bool GetValidData(ref double number, string input)
        {
            if (!double.TryParse(input, out number))
            {
                Console.WriteLine("Incorrect input");
                return false;
            }
            return true;
        }
    }
}
