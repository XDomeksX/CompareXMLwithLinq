using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace XMLUsporedivanjeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement PrviXML = XElement.Load(@"C:\Domenik\VisualStudio\prvi.xml");
            XElement DrugiXML = XElement.Load(@"C:\Domenik\VisualStudio\drugi.xml");
            int brojpomagalo = 0;
            foreach (XElement book in PrviXML.Elements())
            {
                book.Name = "Book" + brojpomagalo.ToString();
                brojpomagalo++;
            }
            brojpomagalo = 0;
            foreach (XElement book in DrugiXML.Elements())
            {
                book.Name = "Book" + brojpomagalo.ToString();
                brojpomagalo++;
            }
            IEnumerable<string> UsporedbaIDova = from s in PrviXML.Elements()
                                                 where s.Attribute("id").Value != DrugiXML.Element(s.Name).Attribute("id").Value
                                                 select "\tid is different\t\t" + s.Attribute("id").Value + "\t\t\t" + DrugiXML.Element(s.Name).Attribute("id").Value;
            IEnumerable<string> UsporedbaImena = from s in PrviXML.Elements()
                                                 where s.Attribute("name").Value != DrugiXML.Element(s.Name).Attribute("name").Value
                                                 select "\tname is different\t" + s.Attribute("name").Value + "\t\t\t" + DrugiXML.Element(s.Name).Attribute("name").Value;
            IEnumerable<string> UsporedbaImage = from s in PrviXML.Elements()
                                                 where s.Attribute("image").Value != DrugiXML.Element(s.Name).Attribute("image").Value
                                                 select "\timage is different\t" + s.Attribute("image").Value + "\t\t\t" + DrugiXML.Element(s.Name).Attribute("image").Value;
            Console.WriteLine("Issued\t\tIssue type\t\tIssueInFirst\t\tIssueInSecond");
            foreach (string s in UsporedbaImage) { Console.WriteLine("1\t" + s.ToString()); }
            foreach (string s in UsporedbaImena) { Console.WriteLine("2\t" + s.ToString()); }
            foreach (string s in UsporedbaIDova) { Console.WriteLine("3\t" + s.ToString()); }
            Console.ReadKey();
        }
    }
}