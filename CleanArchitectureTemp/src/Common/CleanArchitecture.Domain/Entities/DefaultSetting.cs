using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class DefaultSetting : AuditableEntity
    {
        public DefaultSetting()
        {
        }

        public int DefaultSettingId { get; set; }
        public string SettingName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
