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
            string pathIn = @"Data\dane.csv";
            string pathOut = "result.xml";
            string format = "xml";

            if (args.Length == 3)
            {
                pathIn = args[0];
                pathOut = args[1];
                format = args[2];
            }

            var list = new List<Student>();
            var badList = new List<string>();


            string path = pathIn;

            //Wczytywanie 
            var fi = new FileInfo(path);
            try
            {
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    int check = 0;

                    while ((line = stream.ReadLine()) != null)
                    {

                        check = 0;

                        string[] kolumny = line.Split(',');
                        foreach (string s in kolumny)
                        {
                            if (String.IsNullOrWhiteSpace(s) || kolumny.Length != 9)
                            {
                                check = 1;
                                line = "[NIEPRAWIDLOWY FORMAT]" + line;
                                badList.Add(line);
                                break;
                            }
                        }

                        if (check == 1)
                            continue;

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
                        }
                    }
                }
            }
            catch (FileNotFoundException e1)
            {
                badList.Add(e1.Message + "Podana ścieżka jest niepoprawna");
                Console.WriteLine(e1.Message + "Podana ścieżka jest niepoprawna");
                return;

            }
            catch (ArgumentException e2)
            {
                Console.WriteLine(e2.Message + "Podana ścieżka jest niepoprawna");
                badList.Add(e2.Message + "Podana ścieżka jest niepoprawna");
                return;
            }
            catch (Exception e3)
            {
                Console.WriteLine(e3.Message);
                badList.Add(e3.Message);
                return;
            }

                //stream.Dispose();

                //XML

                FileStream writer = new FileStream(pathOut, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            writer.Close();

            using (TextWriter writer1 = new StreamWriter("log.txt"))
            {
                foreach (String s in badList)
                {
                    Console.WriteLine(s);
                    writer1.WriteLine(s);
                }
            }
        }
    }
}
