using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kontur.TestTask
{
    /// <summary>
    /// Интерфейс для чтения списка симпатий из файла, абстрагирующий программу от конкретного типа файла
    /// </summary>
    public interface ISympathyFileReader
    {
        /// <summary>
        /// Читает список симпатий детей
        /// </summary>
        /// <param name="childCollection">Список детей, участвующих в отношениях симпатии</param>
        /// <returns>Список симпатий</returns>
        IEnumerable<Sympathy> ReadFile(IReadOnlyCollection<Child> childCollection);
    }
}
