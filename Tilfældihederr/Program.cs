using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Tilfældihederr;

namespace Tilfældighedstest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> randomNumbers = new List<int>();
            List<int> rngNumbers = new List<int>();

            Console.WriteLine();
            RandomTest();
            foreach (int number in randomNumbers)
            {
                Console.WriteLine($"Random numbers using Random: {number}");
            }

            RandomNumberGeneratorCreateTest();
            foreach (int number in rngNumbers)
            {
                Console.WriteLine($"Random numbers using RandomNumberGenerator: {number}");
            }

            Console.WriteLine("Benchmarking Random vs RandomNumberGenerator");
            RunBenchmark(RandomTest, nameof(RandomTest));
            RunBenchmark(RandomNumberGeneratorCreateTest, nameof(RandomNumberGeneratorCreateTest));

            string originalText = "Hello, my name is Simon";
            string encryptedText = Encrypter.Encrypt(originalText);
            string decryptedText = Encrypter.Decrypt(encryptedText);

            Console.WriteLine($"Original text: {originalText}");
            Console.WriteLine($"Encrypted text: {encryptedText}");
            Console.WriteLine($"Decrypted text: {decryptedText}");


            Console.ReadLine();
        }

        static void RandomTest()
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                numbers.Add(random.Next(0, 1000));
            }
        }

        static void RandomNumberGeneratorCreateTest()
        {
            List<int> numbers = new List<int>();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[4];
                for (int i = 0; i < 1000000; i++)
                {
                    rng.GetBytes(randomBytes); // Fill the array with random bytes
                    int value = BitConverter.ToInt32(randomBytes, 0) & Int32.MaxValue; // Convert bytes to a positive integer
                    numbers.Add(value % 1000); // Make sure the value is within the 0 - 999 range
                }
            }
        }
        private static void RunBenchmark(Action benchmarkMethod, string methodName)
        {
            long startTime = DateTime.Now.Ticks;
            benchmarkMethod();
            long endTime = DateTime.Now.Ticks;
            long elapsedTime = endTime - startTime;
            Console.WriteLine($"{methodName} time (ticks): {elapsedTime}");
        }
    }
}
