using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kontur.TestTask
{
    /// <summary>
    /// Сущность, представляющая симпатию, то есть отношение одного ребенка к другому
    /// </summary>
    public class Sympathy
    {
        /// <summary>
        /// Имя ребенка - субъекта симпатии, то есть ребенок, кто проявляет симпатию
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Имя ребенка - объекта симпатии, то есть ребенок, на кого направлена симпатия
        /// </summary>
        public string Object { get; set; }
    }
}
