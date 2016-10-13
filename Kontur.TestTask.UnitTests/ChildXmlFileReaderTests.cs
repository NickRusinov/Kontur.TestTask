using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace Kontur.TestTask.UnitTests
{
    public class ChildXmlFileReaderTests
    {
        [Fact]
        public void ReadFileTest()
        {
            const string childs = 
                @"<ArrayOfChild>
                    <Child>
                      <Name>Вася</Name>
                    </Child>
                    <Child>
                      <Name>Петя</Name>
                    </Child>
                    <Child>
                      <Name>Маша</Name>
                    </Child>
                  </ArrayOfChild>";

            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(childs));
            var sut = new ChildXmlFileReader(memoryStream);

            var returnsChildCollection = sut.ReadFile().ToList();

            Assert.Equal("Вася", returnsChildCollection[0].Name);
            Assert.Equal("Петя", returnsChildCollection[1].Name);
            Assert.Equal("Маша", returnsChildCollection[2].Name);
        }
    }
}
