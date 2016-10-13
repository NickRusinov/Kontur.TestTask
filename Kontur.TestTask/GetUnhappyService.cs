using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask
{
    /// <summary>
    /// Находит список всех несчастных детей, то есть тех, которые не симпатичны ни одному ребенку из тех, кто симпатичен им самим. 
    /// За исключением тех детей, которым никто не симпатичен
    /// </summary>
    public class GetUnhappyService : IService
    {
        public IEnumerable<Child> Execute(IReadOnlyCollection<Child> childCollection, IReadOnlyCollection<Sympathy> sympathyCollection)
        {
            var sympathyLookup = sympathyCollection.ToLookup(s => s.Subject, s => s.Object);

            var unhappies = new HashSet<string>(
                sympathyLookup.Where(g => !g.Any(n => sympathyLookup[n].Contains(g.Key))).Select(g => g.Key));

            return childCollection.Where(c => unhappies.Contains(c.Name));
        }
    }
}
