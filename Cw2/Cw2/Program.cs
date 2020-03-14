using Cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Student>();
            var badList = new List<string>();


            string path = @"Data\dane.csv";
            Console.WriteLine("Hello World");

            //Wczytywanie 
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                
                while ((line = stream.ReadLine()) != null)
       
                {

                    string[] kolumny = line.Split(',');
                    Console.WriteLine(line);
                    if (kolumny.Length == 9)
                    {
                        list.Add(new Student()
                        {
                            Imie = kolumny[0],
                            Nazwisko = kolumny[1],
                            Studia = kolumny[2],
                            Tryb = kolumny[3],
                            NrIndeksu = kolumny[4],
                            DataUrodzenia = kolumny[5],
                            Email = kolumny[6],
                            ImieMatki = kolumny[7],
                            ImieOjca = kolumny[8]

                        });
                    } else
                    {
                        string str = "";
                        for (int i = 0; i < kolumny.Length; i++)
                        {
                            str += kolumny[i];
                        }
                        badList.Add(str);
                    }
                }
            }
            //stream.Dispose();

            //XML
            var st = new Student
            {
                Imie="Jan",
                Nazwisko="Kowalski",
                Email="kowalski@wp.pl"
            
            };

            list.Add(st);

            FileStream writer = new FileStream("data.xml", FileMode.CreateNew);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            writer.Close();

            using (TextWriter writer1 = new StreamWriter("log.txt"))
            {
                foreach (String s in badList)
                    writer1.WriteLine(s);
            }
        }
    }
}
