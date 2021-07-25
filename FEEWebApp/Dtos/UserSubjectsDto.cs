using System.Collections.Generic;

namespace FEEWebApp.Dtos
{
    public class UserSubjectsDto
    {
        public string UserId { get; set; }
        public List<int> Subjects { get; set; }
    }
}
