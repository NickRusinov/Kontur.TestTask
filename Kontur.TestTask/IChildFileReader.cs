using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kontur.TestTask
{
    /// <summary>
    /// Интерфейс для чтения списка детей из файла, абстрагирующий программу от конкретного типа файла 
    /// </summary>
    public interface IChildFileReader
    {
        /// <summary>
        /// Читает список детей из файла
        /// </summary>
        /// <returns>Список детей</returns>
        IEnumerable<Child> ReadFile();
    }
}
