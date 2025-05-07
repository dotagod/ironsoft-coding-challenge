using System;
using System.Collections.Generic;

namespace OldPhonePad
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = new Dictionary<string, string>
            {
                { "a", "33#" },
                { "b", "4433555 555666#" },
                { "c", "227*#" },
                { "d", "8 88777444666*664#" }
            };

            foreach (var testCase in testCases)
            {
                string name = testCase.Key;
                string inputString = testCase.Value;
                string result = PhoneKeypad.OldPhonePad(inputString);
                
                Console.WriteLine($"Test case {name}: {result}");
            }

        }
    }
}
