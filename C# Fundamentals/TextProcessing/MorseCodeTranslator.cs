using System;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var currCh = input[i];
                switch (currCh)
                {
                    case "|":
                        sb.Append(currCh);
                        sb.Replace(currCh, " ");
                        break;
                    case ".-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "A");
                        break;
                    case "-...":
                        sb.Append(currCh);
                        sb.Replace(currCh, "B");
                        break;
                    case "-.-.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "C");
                        break;
                    case "-..":
                        sb.Append(currCh);
                        sb.Replace(currCh, "D");
                        break;
                    case ".":
                        sb.Append(currCh);
                        sb.Replace(currCh, "E");
                        break;
                    case "..-.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "F");
                        break;
                    case "--.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "G");
                        break;
                    case "....":
                        sb.Append(currCh);
                        sb.Replace(currCh, "H");
                        break;
                    case "..":
                        sb.Append(currCh);
                        sb.Replace(currCh, "I");
                        break;
                    case ".---":
                        sb.Append(currCh);
                        sb.Replace(currCh, "J");
                        break;
                    case "-.-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "K");
                        break;
                    case ".-..":
                        sb.Append(currCh);
                        sb.Replace(currCh, "L");
                        break;
                    case "--":
                        sb.Append(currCh);
                        sb.Replace(currCh, "M");
                        break;
                    case "-.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "N");
                        break;
                    case "---":
                        sb.Append(currCh);
                        sb.Replace(currCh, "O");
                        break;
                    case ".--.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "P");
                        break;
                    case "--.-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "Q");
                        break;
                    case ".-.":
                        sb.Append(currCh);
                        sb.Replace(currCh, "R");
                        break;
                    case "...":
                        sb.Append(currCh);
                        sb.Replace(currCh, "S");
                        break;
                    case "-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "T");
                        break;
                    case "..-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "U");
                        break;
                    case "...-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "V");
                        break;
                    case ".--":
                        sb.Append(currCh);
                        sb.Replace(currCh, "W");
                        break;
                    case "-..-":
                        sb.Append(currCh);
                        sb.Replace(currCh, "X");
                        break;
                    case "-.--":
                        sb.Append(currCh);
                        sb.Replace(currCh, "Y");
                        break;
                    case "--..":
                        sb.Append(currCh);
                        sb.Replace(currCh, "Z");
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", sb));
        }
    }
}