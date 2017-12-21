using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDict Dict = new ClassDict("It", new List<string> { "ОНО", "она", "это", "Он", " нЕго " });
            string c;
            string word;
            string translate;
            Console.WriteLine("Добро пожаловать в словарик!!\n" +
                "Если вы хотите получить перевод введите TL\n" +
                "Если вы хотите добавить слово и перевод к нему, то введите Add\n" +
                "Если вы хотите добавить слово и несколько переводов к нему, то введите Add\n" +
                "Для выхода введите exit\n" +
                "-----------------------------------------------------------------------------");
            while ((c = Console.ReadLine()) != "exit")
            {
                if(c == "Add")
                {
                    Console.Write("Введите слово: ");
                    word = Console.ReadLine();
                    Console.Write("Введите перевод: ");
                    translate = Console.ReadLine();
                    Dict.Add(word, translate);
                }
                if (c == "AddSt")
                {
                    Console.Write("Введите слово: ");
                    word = Console.ReadLine();
                    Console.Write("Введите слова-переводы через пробел:\n");
                    translate = Console.ReadLine();
                    Dict.Add(word, translate.Split().ToList());
                }
                if (c == "TL")
                {
                    Console.Write("Введите слово: ");
                    word = Console.ReadLine();
                    if (Dict.GetTranslate(word) != null)
                    {
                        foreach (string str in Dict.GetTranslate(word))
                            Console.Write("{0};  ", str);
                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine("Нет такого слова");
                  
                }
            }

        }
    }
}
