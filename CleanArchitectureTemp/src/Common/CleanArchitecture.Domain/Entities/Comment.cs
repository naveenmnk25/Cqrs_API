using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public Comment()
        {
        }

        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string Comments { get; set; }
    }
}
