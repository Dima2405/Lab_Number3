using System;
using System.Diagnostics;

namespace Lab_Number3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите верхнюю границу для поиска простых чисел:");
            int n = int.Parse(Console.ReadLine());

            Calculator calculator = new Calculator();
            calculator.Calculate(n);

            Console.ReadKey();
        }
    }
}