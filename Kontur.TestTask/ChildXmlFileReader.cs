using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kontur.TestTask
{
    /// <summary>
    /// Читает список детей из файла в формате xml
    /// </summary>
    public class ChildXmlFileReader : IChildFileReader
    {
        private readonly XmlSerializer xmlSerializer = new  XmlSerializer(typeof(Child[]));

        private readonly Stream xmlStream;

        public ChildXmlFileReader(Stream xmlStream)
        {
            this.xmlStream = xmlStream;
        }

        public IEnumerable<Child> ReadFile()
        {
            var childCollection = (Child[])xmlSerializer.Deserialize(xmlStream);

            if (childCollection.GroupBy(c => c.Name).Any(g => g.Count() > 1))
                throw new Exception("В файле детей присутствуют повторяющиеся имена");

            return childCollection;
        }
    }
}
