using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dto
{
    public class VersionMapDto
    {
        [Key]
        public int? VersionMapId { get; set; }
        public string VersionName { get; set; }
        public string DataFile { get; set; }
        public int TableTypeId { get; set; }
    }

}
