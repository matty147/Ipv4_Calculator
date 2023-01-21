using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipv4_calculator
{
    internal class Program
    {
        static bool validate(string input)
        {
            string allowedChars = "1234567890./ ";
            return input.All(c => allowedChars.Contains(c));
        }

        static string inputIpBasic()
        {
            while (true)
            {

                string input = Console.ReadLine();
                if (validate(input)) return input;
                Console.WriteLine("Wrong input; try again");
            }
        }

        static List<int> inputIp()
        {
            while (true)
            {
                string input = inputIpBasic();
                List<int> parts = input                 // "11.12.13.14/15"
                    .Split('.', '/')                    // ["11", "12", "13", "14", "15"]
                    .Select(s => Int32.Parse(s))        // [11, 12, 13, 14, 15]
                    .ToList();                             

                if (
                    parts.Count == 5 && 
                    parts.All(i => 0 <= i && i <= 255) &&
                    parts[4] <= 32
                )
                    return parts;

                Console.WriteLine("Wrong input; required: number.number.number.number/number");
            }
        }

        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }


        static void Main(string[] args)
        {
            List<int> ipv4 = inputIp();
            Console.WriteLine("------------------");
            foreach (int a in ipv4)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("------------------");

            foreach (int b in ipv4)
            {
                Console.WriteLine(b + (" to bin:"));
                Console.WriteLine(ToBin(b, 8));            
            }
            Console.ReadKey();
        }
        
    }
}
