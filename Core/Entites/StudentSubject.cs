using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class StudentSubject
    {
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public string UserId { get; set; }
    }
}