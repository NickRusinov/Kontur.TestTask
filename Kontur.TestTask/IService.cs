using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask
{
    /// <summary>
    /// Сервис, выполняющий некоторую задачу над симпатиями детей
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Выполнить некоторую задачу над симпатиями детей
        /// </summary>
        /// <param name="childCollection">Список детей</param>
        /// <param name="sympathyCollection">Список симпатий</param>
        /// <returns>Результирующий список детей</returns>
        IEnumerable<Child> Execute(IReadOnlyCollection<Child> childCollection, IReadOnlyCollection<Sympathy> sympathyCollection);
    }
}
