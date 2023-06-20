namespace CleanArchitecture.Application.Dto
{
    public class EntityDataDto
    {
        public EntityDataDto()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private bool _active;

    }
}
