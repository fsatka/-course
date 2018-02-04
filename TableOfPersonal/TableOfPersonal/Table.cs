using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TableOfPersonal
{
        [XmlRoot]
        public class Employee
        {
            //поля сотрудника (по ним инициализируем xml)
            [XmlAnyElement]
            private string _name;
            [XmlAnyElement]
            private string _surname;
            [XmlAnyElement]
            private string _patronymic;
            [XmlAnyElement]
            private string _phone;
            [XmlAnyElement]
            private string _address;

            //для парсинга полей класса
            private static Regex pattern1 = new Regex(@"(^[A-Z]+[a-z-]*?|[А-ЯЁ]+[а-яё-]*?)$");
            private static Regex pattern2 = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"); // взято с https://habrahabr.ru/post/110731/
        #region Свойства  
        public Employee()
            {
                _name = "";
                _surname = "";
                _patronymic = "";
                _phone = "";
                _address = "";
            }

            public string name
            {
                get { return _name; }
                set
                {
                    if (pattern1.IsMatch(value))
                        _name = value;
                    else
                        value = "";
                }

            }

            public string surname
            {
                get { return _surname; }
                set
                {
                if (pattern1.IsMatch(value))
                    _surname = value;
                else
                    value = "";
                    
                }
            }

            public string patronymic
            {
                get { return _patronymic; }
                set
                {
                    if (pattern1.IsMatch(value))
                        _patronymic = value;
                    else
                        value = "";
                }
            }

            public string phone
            {
                get { return _phone; }
                set
                {
                    if (pattern2.IsMatch(value))
                        _phone = value;
                    else
                        value = "";
                }
            }

        public string address
        {
            get { return _address; }
            set
            { 
                    _address = value;
            }
        }
        #endregion


        //поиск информации по полям объекта
        public static bool Search(Employee men, string name = "", string surname = "", string patronymic = "",  string phone = "", string address = "")
        {
            int i = 0, j = 0;
            if (!name.Equals(""))
            {
                j++;
                if (men.name.Equals(name))
                    i++;
            }
            if (!surname.Equals(""))
            {
                j++;
                if (men.surname.Equals(surname))
                    i++;
            }
            if (!patronymic.Equals(""))
            {
                j++;
                if (men.patronymic.Equals(patronymic))
                    i++;
            }
            if (!phone.Equals(""))
            {
                j++;
                if (men.phone.Equals(phone))
                    i++;
            }
            if (!address.Equals(""))
            {
                j++;
                if (men.address.Equals(address))
                    i++;
            }

            if (i == j)
                return true;
            else
                return false;
        }

        //поиск в листе
        public static List<Employee> TableSearch(List<Employee> mens, string name = "", string surname = "", string patronymic = "", string phone = "", string address = "")
        {
            List<Employee> Out = new List<Employee>();
            foreach (Employee men in mens)
                if (Search(men, name, surname, patronymic, phone, address))
                    Out.Add(men);
            return Out;
        }

        //Вывод
        static public void Print(List<Employee> mens)
        {
            if(mens.Count != 0)
            {
                foreach(Employee men in mens)
                    Console.WriteLine("name: {0};         surname: {1};            patrnymic: {2};            phone: {3};            address: {4}", men.name, men.surname, men.patronymic, men.phone, men.address);
            }
            else Console.WriteLine("Пусто");
        }
    }
    
}
