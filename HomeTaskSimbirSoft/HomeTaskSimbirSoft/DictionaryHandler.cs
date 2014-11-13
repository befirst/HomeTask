using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimbirsoftTestTask
{
    class DictionaryHandler
    {
        public List<string> wordsFromDict = new List<string>();
        private string fileName = "Dictionary.txt";

        public void LoadDict() //Загрузка словаря
        {
            string word = "";
            FileStream fs = new FileStream(fileName, FileMode.Open);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    word = sr.ReadLine();
                    wordsFromDict.Add(word);
                }
            }
            fs.Close();
        }

        public void PrintDict()//Печать в консоль
        {
            for (int i = 0; i < wordsFromDict.Count; i++)
                Console.WriteLine(wordsFromDict[i]);
        }

        public string CheckLine(string s) //Проверка на наличие слов из словаря и их форматирование
        {
            foreach (var i in wordsFromDict)
                if (s.Contains(i))
                    s = s.Replace(i, "<b><i>" + i + "</i></b>");
            return s += "<br>";
        }
    }
}
