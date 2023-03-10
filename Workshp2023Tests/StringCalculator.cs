using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshp2023Tests
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (String.IsNullOrEmpty(str) || str.Equals("//X\n")) return 0;

            List<char> separtors = new List<char> { ',', '\n' };

            if (str.StartsWith("//") && char.IsLetter(str[2]) && str[3] == '\n' )
            {
                separtors = new List<char> { str[2] };
                str = str.Substring(4);
            }

            int num = 0;
            {
                string[] numbers = str.Split(separtors.ToArray());
                num = numbers.Sum(n => {
                    if (int.Parse(n) < 0) throw new ArgumentException();
                    if (int.Parse(n) > 100) return 0;
                    return int.Parse(n); 
                });
            }

            return num;
        }
    }
}
