using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace TextExp
{
    class Program
    {
        static void Main()
        {
            
            string path;
            
            
            Console.WriteLine("Введите путь к СSV фаилу:");
            path = Console.ReadLine();
            FileStream file = File.OpenRead(@path);
            StreamReader st = new StreamReader(file);

            Print(Parse(st));
            Console.ReadLine();
            
        }

        static int[] Parse(StreamReader st)
        {
            string[] line;
            int phone_err = 0, email_err = 0, total = 0;
            const string pattern_phone = @"^""((\+7|8)\d{10}|(\+7|8)\(\d{3}\)\d{7}|(\+7|8) \(\d{3}\) \d{7}|(\+7|8) \d{3} \d{7}|(\+7|8)-\d{3}-\d{7})""$";
            const string pattern_email = @"^""\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6}""$";
            Regex regex1 = new Regex(pattern_phone);
            Regex regex2 = new Regex(pattern_email);

            using (st)
            {
                st.ReadLine();
                while (!st.EndOfStream)
                {
                    line = st.ReadLine().Split('\t');

                    if (!regex1.IsMatch(line[2]))
                        phone_err++;
                    if (!regex2.IsMatch(line[1]))
                        email_err++;
                    total++;
                }
            }
            return new int[] {total, phone_err, email_err};
        }
        //C:\Users\Рома\Desktop\Test.csv
        
        static void Print(int[] numbers)
        {
            Console.WriteLine("+"+"-".Times(numbers[0].ToString().Length+14)+"+");
            Console.WriteLine("| "+"total"+" ".Times(4)+" | "+numbers[0] + " |");
            Console.WriteLine("+" + "-".Times(numbers[0].ToString().Length + 14) + "+");
            Console.WriteLine("| " + "phone_err" +  " | " + numbers[1] + " ".Times(numbers[0].ToString().Length - numbers[1].ToString().Length) + " |");
            Console.WriteLine("+" + "-".Times(numbers[0].ToString().Length + 14) + "+");
            Console.WriteLine("| " + "email_err" + " | " + numbers[2] + " ".Times(numbers[0].ToString().Length - numbers[2].ToString().Length) + " |");
            Console.WriteLine("+" + "-".Times(numbers[0].ToString().Length + 14) + "+");
            Console.WriteLine("| " + "phone_cor" + " | " + (numbers[0] - numbers[1]) + " ".Times(numbers[0].ToString().Length - (numbers[0] - numbers[1]).ToString().Length) + " |");
            Console.WriteLine("+" + "-".Times(numbers[0].ToString().Length + 14) + "+");
            Console.WriteLine("| " + "email_cor" + " | " + (numbers[0] - numbers[2]) + " ".Times(numbers[0].ToString().Length - (numbers[0] - numbers[2]).ToString().Length) + " |");
            Console.WriteLine("+" + "-".Times(numbers[0].ToString().Length + 14) + "+");
        }
      
    }

    static class StringExts
    {
        public static string Times(this string @this, int times) =>
            string.Concat(Enumerable.Range(0, times).Select(i => @this));
    }
}
