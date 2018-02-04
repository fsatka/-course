using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace TableOfPersonal
{
    class Program
    {
        static void Main()
        {
            string name = "";
            string surname = "";
            string patranymic = "";
            string phone = "";
            string address = "";

            //Как использовать программу
            Information();

            List<Employee> mens = new List<Employee>();



            if (File.Exists(Environment.CurrentDirectory + "\\Data.xml"))
                using (FileStream stream = new FileStream("Data.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                    mens = (List<Employee>)serializer.Deserialize(stream);
                }
            else
            {
                Console.WriteLine("_________________________");
                Console.WriteLine("| Сохранения не найдены |");
            }
            

            string exp = Console.ReadLine();
            while(!exp.Equals("quit"))
            {
                if(exp.Equals("Add"))
                {
                    Employee men = new Employee();
                    Console.Write("name: ");
                    men.name = Console.ReadLine();
                    Console.Write("surname: ");
                    men.surname = Console.ReadLine();
                    Console.Write("patarnymic: ");
                    men.patronymic = Console.ReadLine();
                    Console.Write("phone: ");
                    men.phone = Console.ReadLine();
                    Console.Write("address: ");
                    men.address = Console.ReadLine();
                    Console.WriteLine("--------------------------------------");
                    mens.Add(men);
                }

                if (exp.Equals("Search"))
                {
                    Console.Write("name: ");
                    name = Console.ReadLine();
                    Console.Write("surname: ");
                    surname = Console.ReadLine();
                    Console.Write("patranymic: ");
                    patranymic = Console.ReadLine();
                    Console.Write("phone: ");
                    phone = Console.ReadLine();
                    Console.Write("address: ");
                    address = Console.ReadLine();
                    Console.WriteLine("--------------------------------------");

                    Employee.Print(Employee.TableSearch(mens, name, surname, patranymic, phone, address));
                    Console.WriteLine("--------------------------------------");
                }

                exp = Console.ReadLine();
               
            }

            using (FileStream stream = new FileStream("Data.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                serializer.Serialize(stream, mens);
            }
        }

        static void Information()
        {
            Console.WriteLine("Список команд:\n 1) Add - добавить информацию в таблицу\n 2) Search - найти информацию из таблицы по заданным данным\n 3) quit - выход из программы\n");
            if (!File.Exists(Environment.CurrentDirectory + "\\Data.xml"))
                Console.WriteLine("Примечание: если отсутствует элемент информации при поиске или добавлении, просто нажмите Enter\n" +
                "Примечание: Ввод ФИО задаётся по шаблону(сначал идут одна или более заглавных букв алфавита лат или кирилица," +
                " затем строчные, допускается пробел) в противном случае строка останется пустой\n" +
                "Примечание: Ввод номера допусается в формате 8**********. О вводе номеров подробнее https://habrahabr.ru/post/110731/");
        }
    }
}
