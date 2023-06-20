namespace CleanArchitecture.Application.Dto
{
    public class TaskDto
    {
        public TaskDto()
        {

        }

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TaskType { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public string parontTask { get; set; }
        public string AssignedTo { get; set; }
    }
}
