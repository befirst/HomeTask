using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimbirsoftTestTask
{
    class Program
    {
        static DictionaryHandler dh = new DictionaryHandler();
        static Html html = new Html();
        public static int limit = 10;

        static void Main(string[] args)
        {
            dh.LoadDict();
            dh.PrintDict();
            action();
            Console.Read();
        }

        public static void action() //Метод записи изменённого исходного текста в html файл с разбиением на файлы
        {
            try
            {
                //string sentence = "";
                string usedline = "";
                FileStream fs = new FileStream("Text.txt", FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    int numOfPage = 1;
                    int numOfString = 1;
                    int numOfFlagString = 0;
                    html.BeginHtml(numOfPage);
                    while (!sr.EndOfStream)
                    {
                        usedline = sr.ReadLine();
                        usedline = dh.CheckLine(usedline);
                        html.AddString(usedline, numOfPage);
                        //Console.WriteLine(usedline);
                        int flag = usedline.IndexOf('.');
                        //if (flag > -1) 
                        //{
                        numOfFlagString = numOfString;
                        //sentence += usedline.Remove(flag) + '.';
                        if (numOfString == limit)
                        {
                            html.EndHtml(numOfPage);
                            numOfPage++;
                            numOfString = 1;
                            html.BeginHtml(numOfPage);
                        }
                        //Console.WriteLine(sentence);
                        //sentence = usedline.Substring(flag+1);
                        flag = 0;
                        //}
                        //else { sentence += usedline; Console.WriteLine(sentence); }
                        numOfString++;
                    }
                    html.EndHtml(numOfPage);
                }
                fs.Close();
                Console.WriteLine("Файлы успешно созданы");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
