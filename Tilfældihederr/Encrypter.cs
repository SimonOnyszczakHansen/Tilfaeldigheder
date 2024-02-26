using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilfældihederr
{
    public static class Encrypter
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";

        public static string Encrypt(string text)
        {
            var encrypted = "";
            foreach (char c in text.ToUpper()) 
            {
                if (Alphabet.Contains(c))
                {
                    int index = (Alphabet.IndexOf(c) + 1);
                    encrypted += Alphabet[index];
                }
                else
                {
                    encrypted += c;
                }
            }
            return encrypted;
        }
        public static string Decrypt(string text)
        {
            var decrypted = "";

            foreach (char c in text) 
            {
                if (Alphabet.Contains(c))
                {
                    int index = (Alphabet.IndexOf(c) - 1 + Alphabet.Length) % Alphabet.Length;
                    decrypted += Alphabet[index];
                }
                else
                {
                    decrypted += c;
                }
            }
            return decrypted;
        }
    }
}
