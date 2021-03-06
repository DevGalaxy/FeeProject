using System;

namespace Core.Entites
{
    public class Events : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime EventTime { get; set; }
    }
}
