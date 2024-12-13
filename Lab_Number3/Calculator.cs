using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lab_Number3
{
    public class Calculator
    {
        public void Calculate(int n)
        {
            SequentialWork sequentialSee = new SequentialWork();
            Stopwatch stopwatch = new Stopwatch();

            // Последовательный алгоритм
            stopwatch.Start();
            List<int> sequentialPrimes = sequentialSee.FindPrimes(n);
            stopwatch.Stop();
            long sequentialTime = stopwatch.ElapsedMilliseconds;

            // Модифицированный алгоритм
            stopwatch.Restart();
            List<int> modifiedPrimes = sequentialSee.ModifiedFindPrimes(n);
            stopwatch.Stop();
            long modifiedTime = stopwatch.ElapsedMilliseconds;


            List<int> basePrimes = sequentialSee.FindPrimes((int)Math.Sqrt(n)); // Получение базовых простых чисел
            ParallelWork parallelSee = new ParallelWork();

            // Параллельный алгоритм 1: декомпозиция по данным
            stopwatch.Restart();
            List<int> parallelPrimes1 = parallelSee.FindPrimes(n, basePrimes);
            stopwatch.Stop();
            long parallelTime1 = stopwatch.ElapsedMilliseconds;

            // Параллельный алгоритм №2: Декомпозиция набора простых чисел
            stopwatch.Restart();
            List<int> parallelPrimes2 = parallelSee.ParallelDecomposition(n, basePrimes);
            stopwatch.Stop();
            long parallelTime2 = stopwatch.ElapsedMilliseconds;

            // Параллельный алгоритм 3: Применение пула потоков
            stopwatch.Restart();
            List<int> parallelPrimes3 = parallelSee.ThreadPoolMethod(n, basePrimes);
            stopwatch.Stop();
            long parallelTime3 = stopwatch.ElapsedMilliseconds;

            // Параллельный алгоритм №4: Последовательный перебор простых чисел
            stopwatch.Restart();
            List<int> parallelPrimes4 = parallelSee.SequentialPrimeIteration(n, basePrimes);
            stopwatch.Stop();
            long parallelTime4 = stopwatch.ElapsedMilliseconds;

            // Расчет ускорения и эффективности (модифицированный)
            double speedupModified = (double)sequentialTime / modifiedTime;
            double efficiencyModified = speedupModified / Environment.ProcessorCount;

            // Расчет ускорения и эффективности (параллельный)
            double speedupParallel1 = (double)sequentialTime / parallelTime1;
            double efficiencyParallel1 = speedupParallel1 / Environment.ProcessorCount;

            double speedupParallel2 = (double)sequentialTime / parallelTime2;
            double efficiencyParallel2 = speedupParallel2 / Environment.ProcessorCount;

            double speedupParallel3 = (double)sequentialTime / parallelTime3;
            double efficiencyParallel3 = speedupParallel3 / Environment.ProcessorCount;

            double speedupParallel4 = (double)sequentialTime / parallelTime4;
            double efficiencyParallel4 = speedupParallel4 / Environment.ProcessorCount;

            // Вывод результатов
            Console.WriteLine($"Последовательное время: {sequentialTime} мс");
            Console.WriteLine($"Модифицированное время: {modifiedTime} мс");

            Console.WriteLine($"Параллельное время 1: {parallelTime1} мс");
            Console.WriteLine($"Параллельное время 2: {parallelTime2} мс");
            Console.WriteLine($"Параллельное время 3: {parallelTime3} мс");
            Console.WriteLine($"Параллельное время 4: {parallelTime4} мс");

            Console.WriteLine($"Ускорение (модифицированный): {speedupModified}");
            Console.WriteLine($"Эффективность (модифицированный): {efficiencyModified}");

            Console.WriteLine($"Ускорение (параллельный 1): {speedupParallel1}");
            Console.WriteLine($"Эффективность (параллельный 1): {efficiencyParallel1}");

            Console.WriteLine($"Ускорение (параллельный 2): {speedupParallel2}");
            Console.WriteLine($"Эффективность (параллельный 2): {efficiencyParallel2}");

            Console.WriteLine($"Ускорение (параллельный 3): {speedupParallel3}");
            Console.WriteLine($"Эффективность (параллельный 3): {efficiencyParallel3}");

            Console.WriteLine($"Ускорение (параллельный 4): {speedupParallel4}");
            Console.WriteLine($"Эффективность (параллельный 4): {efficiencyParallel4}");
        }
    }
}
