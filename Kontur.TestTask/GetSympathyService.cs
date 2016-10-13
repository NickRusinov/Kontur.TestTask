using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask
{
    public class GetSympathyService: IService
    {
        public IEnumerable<Child> Execute(IReadOnlyCollection<Child> childCollection, IReadOnlyCollection<Sympathy> sympathyCollection)
        {
            var sympathies = sympathyCollection.ToLookup(s => s.Object);
            var maxSympathy = sympathies.Max(g => g.Count());

            var maxSympathies = new HashSet<string>(
                sympathies.Where(g => g.Count() == maxSympathy).Select(g => g.Key));

            return childCollection.Where(c => maxSympathies.Contains(c.Name));
        }
    }
}
