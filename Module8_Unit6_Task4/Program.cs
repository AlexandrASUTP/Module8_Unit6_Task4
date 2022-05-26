using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module8_Unit6_Task4
{
    [Serializable]
    class Student
    {
        
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }


        public Student(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }
    
    class Program
    {
        static string ReadFile(string p)
        {
           string Value = null;
            if (File.Exists(@p))
            {
                

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(@p, FileMode.Open)))
                {
                    Value = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(Value);
                
            }
            return Value;
        }
        static void CreateFile(string path, string data)
        {
            if (!File.Exists(path)) // Проверим, существует ли файл по данному пути
            {
                //   Если не существует - создаём и записываем в строку
                using (StreamWriter sw = File.CreateText(path))  
                {
                    sw.WriteLine(data);
                   
                }
            }
        }
        static void Main(string[] args)
        {
            string data = ReadFile("C:\\Students.dat");
            CreateFile("C:\\Studentss.txt", data);
        }
    }
}
