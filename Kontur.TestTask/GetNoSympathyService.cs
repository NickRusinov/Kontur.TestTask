﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask
{
    /// <summary>
    /// Гаходит список всех не любимчиков, то есть детей которые никому не симпатичны
    /// </summary>
    public class GetNoSympathyService : IService
    {
        public IEnumerable<Child> Execute(IReadOnlyCollection<Child> childCollection, IReadOnlyCollection<Sympathy> sympathyCollection)
        {
            var sympathies = new HashSet<string>(
                sympathyCollection.Select(s => s.Object));

            return childCollection.Where(c => !sympathies.Contains(c.Name));
        }
    }
}
