﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kontur.TestTask.UnitTests
{
    public class GetUnhappyServiceTests
    {
        [Fact]
        public void ExecuteTest()
        {
            var childs = new[]
            {
                new Child { Name = "Вася" },
                new Child { Name = "Петя" },
                new Child { Name = "Маша" },
                new Child { Name = "Катя" },
            };

            var sympathies = new[]
            {
                new Sympathy { Subject = "Вася", Object = "Маша" },
                new Sympathy { Subject = "Маша", Object = "Петя" },
                new Sympathy { Subject = "Петя", Object = "Маша" },
            };

            var sut = new GetUnhappyService();
            var resultsChilds = sut.Execute(childs, sympathies).ToList();

            Assert.Equal(1, resultsChilds.Count);
            Assert.Equal("Вася", resultsChilds[0].Name);
        }
    }
}
