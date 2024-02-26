using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tilfældihederr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> randomNumber = RandomTest();
            List<int> rngNumbers = RandomTest();

            foreach (int number in randomNumber)
            {
               Console.WriteLine($"Random number: {number}");
            }


            foreach (int number in rngNumbers)
            {
                Console.WriteLine($"rng number: {number}");
            }

            Console.ReadLine();
        }

        static List<int> RandomTest() 
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 100; i++) 
            {
                numbers.Add(random.Next(0, 1000));
            }
            return numbers;
        }
        static List<int> RandomNumberGeneratorCreateTest()
        {
            List<int> numbers = new List<int>();
            for (int i = 0;i < 100;i++) 
            {
                byte[] randomBytes = new byte[4];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomBytes);

                }
            }
        }
    }
}
