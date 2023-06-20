namespace CleanArchitecture.Application.Dto
{
    public class CommentDto
    {
        public CommentDto()
        {

        }

        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string Comments { get; set; }
    }
}
