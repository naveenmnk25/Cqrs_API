namespace CleanArchitecture.Application.Dto
{
    public class DeveloperDto
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public int? ManagerId { get; set; }
        public string Manager { get; set; }
        public int? TeamId { get; set; }
        public string Team { get; set; }
    }
}
