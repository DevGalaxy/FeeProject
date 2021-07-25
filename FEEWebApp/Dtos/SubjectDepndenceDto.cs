using System.Collections.Generic;

namespace FEEWebApp.Dtos
{
    public class SubjectDepndenceDto
    {
        public int SubjectId { get; set; }
        public List<int> DepndencesIds { get; set; }

    }
}
