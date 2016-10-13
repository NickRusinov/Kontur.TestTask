using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace Kontur.TestTask.UnitTests
{
    public class SympathyFileReaderTests
    {
        [Fact]
        public void ReadFileTest()
        {
            var childCollection = new[]
            {
                new Child { Name = "Вася" },
                new Child { Name = "Петя" },
                new Child { Name = "Маша" },
            };

            const string sympathies =
                @"<ArrayOfSympathy>
                   <Sympathy>
                    <Subject>Вася</Subject>
                    <Object>Маша</Object>
                   </Sympathy>
                   <Sympathy>
                    <Subject>Маша</Subject>
                    <Object>Петя</Object>
                   </Sympathy>
                 </ArrayOfSympathy>";
            
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(sympathies));
            var sut = new SympathyXmlFileReader(memoryStream);

            var returnsSympathyCollection = sut.ReadFile(childCollection).ToList();

            Assert.Equal("Вася", returnsSympathyCollection[0].Subject);
            Assert.Equal("Маша", returnsSympathyCollection[0].Object);
            Assert.Equal("Маша", returnsSympathyCollection[1].Subject);
            Assert.Equal("Петя", returnsSympathyCollection[1].Object);
        }
    }
}
