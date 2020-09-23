using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace HelloApp
{
    class Program
    {
        public static bool WriteIndented { get; private set; }

        public static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("sfgaegegae");
                    DriveInfo[] drives = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in drives)
                    {
                        Console.WriteLine($"Название: {drive.Name}");
                        Console.WriteLine($"Тип: {drive.DriveType}");
                        if (drive.IsReady)
                        {
                            Console.WriteLine($"Объемдиска: {drive.TotalSize}");
                            Console.WriteLine($"Свободноепространство: {drive.TotalFreeSpace}");
                            Console.WriteLine($"Метка: {drive.VolumeLabel}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    string PATH = @"D:\sss.txt";
                    FileInfo file = new FileInfo(PATH);





                    string text = "hello world";

                    // записьвфайл
                    using (FileStream fstream = new FileStream(PATH, FileMode.OpenOrCreate))
                    {
                        // преобразуемстрокувбайты
                        byte[] input = Encoding.Default.GetBytes(text);
                        // записьмассивабайтоввфайл
                        fstream.Write(input, 0, input.Length);
                        Console.WriteLine("Текст записан в файл");

                        // перемещаем указатель в конец файла, до конца файла- пять байт
                        fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока

                        // считываем четыре символов с текущей позиции
                        byte[] output = new byte[4];
                        fstream.Read(output, 0, output.Length);
                        // декодируембайтывстроку
                        string textFromFile = Encoding.Default.GetString(output);
                        Console.WriteLine($"Текст из файла: {textFromFile}"); // worl

                        // заменим в файле слово world на слово house
                        string replaceText = "house";
                        fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока
                        input = Encoding.Default.GetBytes(replaceText);
                        fstream.Write(input, 0, input.Length);

                        // считываем весь файл
                        // возвращаем указатель в начало файла
                        fstream.Seek(0, SeekOrigin.Begin);
                        output = new byte[fstream.Length];
                        fstream.Read(output, 0, output.Length);
                        // декодируембайтывстроку
                        textFromFile = Encoding.Default.GetString(output);
                        Console.WriteLine($"Текст из файла: {textFromFile}"); // hello house

                     
                    }
                    



                    if (file.Exists)
                    {
                        Console.WriteLine("Имяфайла: {0}", file.Name);
                        Console.WriteLine("Времясоздания: {0}", file.CreationTime);
                        Console.WriteLine("Размер: {0}", file.Length);
                        Console.WriteLine(file.Extension);

                    }
                    if (file.Exists)
                    {
                        file.Delete();
                        // альтернатива с помощью класса File
                        // File.Delete(path);
                        Console.WriteLine("файл удален");
                    }
                        break;
                case 3:
                    
                        var xml = new XmlDocument();
                        xml.LoadXml("<item><text>hello</text></item>");
                        XmlElement xmlel = xml.CreateElement("test1");
                        XmlWriter writer = XmlWriter.Create(@"D:\test.xml");
                        xml.Save(writer);
                        Console.WriteLine(xml.InnerXml);
                        Console.ReadKey();
                        writer.Close();
                        File.Delete(@"D:\test.xml");
                    


                    break;
                case 4:

                    var options = new JsonSerializerOptions();
{
                        WriteIndented = true;
};

                    Person tom = new Person { Name = "Tom", Age = 35 };
                    string json = JsonSerializer.Serialize<Person>(tom, options);
                    Console.WriteLine(json);
                    Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
                    Console.WriteLine(restoredPerson.Name);
                    break;

            }
        }

        class Person
        {
            public string Name;
          public  int Age;
        }
    }
}


