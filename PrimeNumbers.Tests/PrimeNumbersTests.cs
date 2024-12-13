using Lab_Number3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace PrimeNumbers.Tests
{
    [TestClass]
    public class PrimeNumbersTests
    {
        [TestMethod]
        public void SequentialAlgorithm_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;
            SequentialWork sequentialWork = new SequentialWork();

            // Действие
            List<int> primes = sequentialWork.FindPrimes(n);


            // Проверка 
            Assert.AreEqual(25, primes.Count); // Ожидаемое значение
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));

        }


        [TestMethod]
        public void ModifiedAlgorithm_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;
            SequentialWork sequentialWork = new SequentialWork();

            // Действие
            List<int> primes = sequentialWork.ModifiedFindPrimes(n);

            // Проверка
            Assert.AreEqual(25, primes.Count);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));

        }


        [TestMethod]
        public void ParallelAlgorithm1_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;

            ParallelWork parallelWork = new ParallelWork();

            List<int> basePrimes = new SequentialWork().FindPrimes((int)Math.Sqrt(n)); //  находит простые числа, которые меньше или равны квадратному корню из n

            // Действие
            List<int> primes = parallelWork.FindPrimes(n, basePrimes);

            // Проверка
            Assert.AreEqual(25, primes.Count);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));


        }


        [TestMethod]
        public void ParallelAlgorithm2_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;

            ParallelWork parallelWork = new ParallelWork();

            List<int> basePrimes = new SequentialWork().FindPrimes((int)Math.Sqrt(n));


            // Действие
            List<int> primes = parallelWork.ParallelDecomposition(n, basePrimes);


            // Проверка
            Assert.AreEqual(25, primes.Count);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));

        }


        [TestMethod]
        public void ParallelAlgorithm3_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;

            ParallelWork parallelWork = new ParallelWork();
            List<int> basePrimes = new SequentialWork().FindPrimes((int)Math.Sqrt(n));


            // Действие
            List<int> primes = parallelWork.ThreadPoolMethod(n, basePrimes);


            // Проверка
            Assert.AreEqual(25, primes.Count);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));

        }


        [TestMethod]
        public void ParallelAlgorithm4_ReturnsCorrectPrimes()
        {

            // Подготовка
            int n = 100;

            ParallelWork parallelWork = new ParallelWork();
            List<int> basePrimes = new SequentialWork().FindPrimes((int)Math.Sqrt(n));


            // Действие
            List<int> primes = parallelWork.SequentialPrimeIteration(n, basePrimes);


            // Проверка
            Assert.AreEqual(25, primes.Count);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));

        }
    }
}