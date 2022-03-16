using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dostowinFramework
{
    class Program
    {
        //Developed by Onohov Aleksey 
        //https://github.com/Onokin/DosToWinConverter
        static void Main(string[] args)
        {
            try
            {
                string path = args[0];
                var win1251 = Encoding.GetEncoding(1251);
                var dos866 = Encoding.GetEncoding(866);
                var lines = File.ReadAllLines(path, win1251);
                List<string> dosLines = new List<string>();
                foreach (var line in lines)
                {
                    var aux = dos866.GetString(win1251.GetBytes(line));
                    dosLines.Add(aux);
                    Console.WriteLine(aux);
                }
                File.WriteAllLines(path, dosLines.ToArray());
                Console.WriteLine("Task completed succesfully! \nКонвертирование завершено успешно!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("Error! \nОшибка!");
                Console.ReadLine();
            }
        }

    }
}
