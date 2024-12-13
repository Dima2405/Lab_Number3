using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_Number3
{
    public class ParallelWork
    {
        private bool[] InitializeIsPrimeArray(int n) //инициализируем массив, который будет использоваться для отслеживания простых чисел.
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }
            return isPrime;
        }

        public List<int> FindPrimes(int n, List<int> basePrimes) // Параллельный алгоритм №1: декомпозиция по данным
        {
            bool[] isPrime = InitializeIsPrimeArray(n); // Инициализация массива

            Parallel.ForEach(basePrimes, (prime) => // параллельная обработки каждого простого числа из списка basePrimes.
            {
                for (int i = prime * prime; i <= n; i += prime)
                {
                    // Используем lock для предотвращения конкурентного доступа
                    lock (isPrime)
                    {
                        isPrime[i] = false;
                    }
                }
            });

            return GetPrimes(isPrime); //Возврат результатов
        }

        // Параллельный алгоритм №2: Декомпозиция набора простых чисел
        public List<int> ParallelDecomposition(int n, List<int> basePrimes)
        {
            bool[] isPrime = InitializeIsPrimeArray(n); // Инициализация массива
            int numberOfThreads = Environment.ProcessorCount; // возвращаем количество доступных процессоров, что позволяет оптимально распределить нагрузку.

            Parallel.For(0, numberOfThreads, (threadIndex) => // цикл, который выполняется параллельно, где каждый поток обрабатывает свою часть базовых простых чисел.
            {
                for (int i = threadIndex; i < basePrimes.Count; i += numberOfThreads)
                {
                    int prime = basePrimes[i];
                    for (int j = prime * prime; j <= n; j += prime) //Отметка составных чисел
                    {
                        lock (isPrime)
                        {
                            isPrime[j] = false;
                        }
                    }
                }
            });

            return GetPrimes(isPrime); //Возврат результатов
        }

        // Параллельный алгоритм №3: Применение пула потоков
        public List<int> ThreadPoolMethod(int n, List<int> basePrimes)
        {
            bool[] isPrime = InitializeIsPrimeArray(n); // Инициализация массива
            CountdownEvent countdown = new CountdownEvent(basePrimes.Count); // отслеживание количество потоков, завершивших свою работу

            foreach (var prime in basePrimes) // итерация по простым числам
            {
                int localPrime = prime; // локальная переменная для замыкания
                ThreadPool.QueueUserWorkItem((state) => // Добавление задачи в пул потоков
                {
                    for (int j = localPrime * localPrime; j <= n; j += localPrime) // Отметка составных чисел
                    {
                        lock (isPrime)
                        {
                            isPrime[j] = false;
                        }
                    }
                    countdown.Signal(); // Уменьшаем счетчик при завершении работы потока
                });
            }

            countdown.Wait(); //Ожидание завершения всех потоков
            return GetPrimes(isPrime); //Возврат результатов
        }

        // Параллельный алгоритм №4: Последовательный перебор простых чисел
        public List<int> SequentialPrimeIteration(int n, List<int> basePrimes)
        {
            bool[] isPrime = InitializeIsPrimeArray(n); // Инициализация массива
            List<Task> tasks = new List<Task>(); //Создание списка задач

            foreach (var prime in basePrimes) //Итерация по простым числам
            {
                tasks.Add(Task.Run(() =>
                {    // Отметка составных чисел:
                    for (int j = prime * prime; j <= n; j += prime)
                    {
                        lock (isPrime)
                        {
                            isPrime[j] = false;
                        }
                    }
                }));
            }

            // Ожидание завершения всех задач
            Task.WaitAll(tasks.ToArray());

            return GetPrimes(isPrime); //Возврат результатов
        }

        private List<int> GetPrimes(bool[] isPrime) //извлекаем простые числа из массива
        {
            List<int> primes = new List<int>();
            for (int p = 2; p < isPrime.Length; p++)
            {
                if (isPrime[p])
                {
                    primes.Add(p);
                }
            }
            return primes;
        }
    }
}
