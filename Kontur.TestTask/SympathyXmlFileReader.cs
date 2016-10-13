using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kontur.TestTask
{
    public class SympathyXmlFileReader : ISympathyFileReader
    {
        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(Sympathy[]));

        private readonly Stream xmlStream;

        public SympathyXmlFileReader(Stream xmlStream)
        {
            this.xmlStream = xmlStream;
        }

        public IEnumerable<Sympathy> ReadFile(IReadOnlyCollection<Child> childCollection)
        {
            var sympathyCollection = (Sympathy[])xmlSerializer.Deserialize(xmlStream);
            var childNames = new HashSet<string>(childCollection.Select(c => c.Name));

            if (sympathyCollection.GroupBy(s => new { s.Subject, s.Object }).Any(g => g.Count() > 1))
                throw new Exception("В файле симпатий присутствуют дубликаты");

            if (!sympathyCollection.All(s => childNames.Contains(s.Subject) && childNames.Contains(s.Object)))
                throw new Exception("В файле симпатий найден неизвестный ребенок");

            if (sympathyCollection.Any(s => s.Subject == s.Object))
                throw new Exception("Ребенок не может быть симпатичен сам себе");

            return sympathyCollection;
        }
    }
}
