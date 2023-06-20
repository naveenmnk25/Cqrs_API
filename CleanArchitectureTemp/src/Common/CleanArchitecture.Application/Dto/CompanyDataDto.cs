using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dto
{
    public class CompanyDataDto
    {
        public CompanyDataDto()
        {

        }
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string Reference { get; set; }
        public string ToolVersion { get; set; }
        public string LanguageCodes { get; set; }
        public int DisplayNYear { get; set; }
    }
}
