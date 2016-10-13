using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask
{
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
