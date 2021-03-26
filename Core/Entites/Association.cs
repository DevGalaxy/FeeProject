using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    /// <summary>
    /// Related to other componentes in the Faculty For Ex: Librarry
    /// </summary>
    public class Association : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CoverPath { get; set; }
    }
}
