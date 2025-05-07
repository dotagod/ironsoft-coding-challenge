using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public class PhoneKeypad
    {
        private const char SPACE = ' ';
        private const char BACKSPACE = '*';
        private const char SEND = '#';

        private static readonly Dictionary<char, string> KeyMap = new Dictionary<char, string>
        {
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            char? lastDigit = null;
            int consecutivePresses = 0;

            foreach (char c in input)
            {
                switch (c)
                {
                    case SPACE:
                        AppendCurrentCharacter(result, lastDigit, consecutivePresses);
                        lastDigit = null;
                        consecutivePresses = 0;
                        break;

                    case BACKSPACE:
                        lastDigit = null;
                        consecutivePresses = 0;
                        
                        if (result.Length > 0)
                            result.Length--;
                        break;

                    case SEND:
                        AppendCurrentCharacter(result, lastDigit, consecutivePresses);
                        lastDigit = null;
                        consecutivePresses = 0;
                        break;

                    default:
                        if (!KeyMap.ContainsKey(c))
                            continue;

                        if (lastDigit != c)
                        {
                            AppendCurrentCharacter(result, lastDigit, consecutivePresses);
                            lastDigit = c;
                            consecutivePresses = 1;
                        }
                        else
                        {
                            consecutivePresses++;
                        }
                        break;
                }
            }

            AppendCurrentCharacter(result, lastDigit, consecutivePresses);
            return result.ToString();
        }

        private static void AppendCurrentCharacter(StringBuilder result, char? digit, int presses)
        {
            if (!digit.HasValue || presses == 0)
                return;

            string letters = KeyMap[digit.Value];
            int index = (presses - 1) % letters.Length;
            result.Append(letters[index]);
        }
    }
}