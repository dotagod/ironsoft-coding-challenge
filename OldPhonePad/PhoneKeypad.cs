using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public class PhoneKeypad
    {
        public static string OldPhonePad(string input)
        {
            Dictionary<char, string> map = new Dictionary<char, string>
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

            string result = "";
            string currentSequence = "";
            int position = 0;

            while (position < input.Length)
            {
                char currentChar = input[position];
                position++;

                switch (currentChar)
                {
                    case ' ':
                        result = ProcessCurrentSequence(map, currentSequence, result);
                        currentSequence = "";
                        break;

                    case '*':
                        result = ProcessCurrentSequence(map, currentSequence, result);
                        currentSequence = "";
                        
                        if (result.Length > 0)
                        {
                            result = result.Substring(0, result.Length - 1);
                        }
                        break;

                    case '#':
                        result = ProcessCurrentSequence(map, currentSequence, result);
                        currentSequence = "";
                        break;

                    default:
                        if (map.ContainsKey(currentChar))
                        {
                            if (currentSequence == "" || currentSequence[0] == currentChar)
                            {
                                currentSequence += currentChar;
                            }
                            else
                            {
                                result = ProcessCurrentSequence(map, currentSequence, result);
                                currentSequence = currentChar.ToString();
                            }
                        }
                        break;
                }
            }

            result = ProcessCurrentSequence(map, currentSequence, result);
            return result;
        }

        private static string ProcessCurrentSequence(Dictionary<char, string> map, string sequence, string result)
        {
            if (sequence.Length > 0 && map.ContainsKey(sequence[0]))
            {
                string letters = map[sequence[0]];
                int index = (sequence.Length - 1) % letters.Length;
                
                if (index < letters.Length)
                {
                    result += letters[index];
                }
            }
            return result;
        }
    }
}