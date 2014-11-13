using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimbirsoftTestTask
{
    class Html
    {
        public string name = "example";

        public void BeginHtml(int numFile)//Добавление тегов названия и тела для html файла
        {
            FileStream fs = new FileStream(name + " " + numFile + ".html", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<body>");
            }
            fs.Close();
        }

        public void EndHtml(int numFile)//Добавление тегов конца названия и конца объявления тела
        {
            FileStream fs = new FileStream(name + " " + numFile + ".html", FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            fs.Close();
        }

        public void AddString(string s, int numFile)//Добавление строки в файл
        {
            FileStream fs = new FileStream(name + " " + numFile + ".html", FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs))
                sw.WriteLine(s);
            fs.Close();
        }
    }
}
