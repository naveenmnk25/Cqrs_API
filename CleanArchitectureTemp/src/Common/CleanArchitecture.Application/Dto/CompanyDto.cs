using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dto
{
    public partial class CompanyDto
    {
        public CompanyDto()
        {

        }
        [Key]
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Guid Reference { get; set; }
        public string ToolVersion { get; set; }
        public int DisplayNYear { get; set; }
    }
}
