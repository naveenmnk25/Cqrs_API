namespace CleanArchitecture.Application.Dto
{
    public class AttributeDataDto
    {
        public AttributeDataDto()
        {

        }
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        private bool _active;

    }
}
