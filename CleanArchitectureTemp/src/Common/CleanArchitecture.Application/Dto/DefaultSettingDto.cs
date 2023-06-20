namespace CleanArchitecture.Application.Dto
{
    public class DefaultSettingDto
    {
        public DefaultSettingDto()
        {
        }

        public int DefaultSettingId { get; set; }
        public string SettingName { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}