using System;
using System.Collections.Generic;

namespace Lab_Number3
{
    public class SequentialWork
    {

        public List<int> FindPrimes(int n) // нахождения простых чисел от 2 до n
        {
            bool[] isPrime = new bool[n + 1]; // массив isPrime будет хранить информацию о том, является ли число простым

            for (int i = 2; i <= n; i++) // от 2 до n как простые
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= n; p++)//для отметки составных чисел, начиная с квадратов простых чисел
            {

                if (isPrime[p])
                {

                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }

                }

            }

            List<int> primes = new List<int>(); //собираем все простые числа в список и возвращаем его
            for (int p = 2; p <= n; p++)
            {

                if (isPrime[p])
                {
                    primes.Add(p);
                }

            }
            return primes;

        }

        // Новый метод для модифицированного последовательного алгоритма
        public List<int> ModifiedFindPrimes(int n)
        {

            // 1 этап: нахождение базовых простых чисел
            int limit = (int)Math.Sqrt(n);
            List<int> basePrimes = FindPrimes(limit);

            // 2 этап: нахождение простых чисел в интервале от limit до n
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            // Используем базовые простые числа для отметки составных чисел
            foreach (int prime in basePrimes)
            {

                for (int i = Math.Max(prime * prime, 2); i <= n; i += prime)

                {
                    isPrime[i] = false;
                }

            }

            List<int> primes = new List<int>(); // создаём список для хранения простых чисел 
            for (int p = 2; p <= n; p++)// от 2 до n

            {
                if (isPrime[p])
                {
                    primes.Add(p); // добавляем простые числа в список primes
                }

            }

            return primes;

        }
    }
}