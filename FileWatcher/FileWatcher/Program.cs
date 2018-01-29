using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace FileWatcher
{
    class Program
    {
        static string log_file;

        static void Main()
        {
            Run();
        }

        static void Run()
        {
            //память для путей к фаилу
            string path;
      
            //инициализация
            Console.WriteLine("Введите путь к папке:");
            path = Console.ReadLine();
            Console.WriteLine("Путь к лог фаилу");
            log_file = Console.ReadLine();

            //создание объектов
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            //NotifyFilters.LastAccess | 
            //за какими событиями следить
            watcher.NotifyFilter = NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
            
            watcher.Filter = "*.cs";

            //Подписываемся на события
            watcher.Changed += new FileSystemEventHandler(OnChanged2);
            watcher.Created += new FileSystemEventHandler(OnChanged1);
            watcher.Deleted += new FileSystemEventHandler(OnChanged3);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            //начинаем следить
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");
            Console.WriteLine("| "+"Date:      Time:" + " ".Times(DateTime.UtcNow.ToString().Length - "Date:   Time:".Length-2) + "| " + "STATUS" + "  |");
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");
            Console.ReadLine();

        }
        //C:\Users\Рома\Desktop
        //C:\Users\Рома\Documents\LOG_FILE
        private static void OnChanged1(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            
            Console.Write("| " + DateTime.UtcNow+" | ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("CREATED");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" | " + e.Name);
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");
            
            StreamWriter st = File.AppendText(log_file);

            using (st)
            {
                st.WriteLine(DateTime.UtcNow + "    CREATED    " + e.Name);
            }
            

        }

        private static void OnChanged2(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.

            Console.Write("| " + DateTime.UtcNow + " | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("CHANGED");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" | " + e.Name);
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");
            StreamWriter st = File.AppendText(log_file);

            using (st)
            {
                st.WriteLine(DateTime.UtcNow + "    CHANGED    " + e.Name);
            }
            
        }
        private static void OnChanged3(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.

            Console.Write("| " + DateTime.UtcNow + " | ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("DELETED");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" | " + e.Name);
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");
            StreamWriter st = File.AppendText(log_file);

            using (st)
            {
                st.WriteLine(DateTime.UtcNow + "    DELETED    " + e.Name);
            }
          
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.Write("| " + DateTime.UtcNow + " | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("RENAMED");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" | " + "File: {0}  renamed to  {1}", e.OldName, e.Name);
            Console.WriteLine("+-" + "-".Times(DateTime.UtcNow.ToString().Length + 3 + 7) + "-+");

            StreamWriter st = File.AppendText(log_file);
            using (st)
            {
                st.WriteLine(DateTime.UtcNow + "    RENAMED    " + "File:" + e.OldName + "renamed to" + e.Name);
            }
            
        }
    }

    static class StringExts
    {
        public static string Times(this string @this, int times) =>
            string.Concat(Enumerable.Range(0, times).Select(i => @this));
    }
}
