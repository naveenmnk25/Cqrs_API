
using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public partial class Language : AuditableEntity
    {
        public Language()
        {
        }
        [Key]
        public int LanguageId { get; set; }
        public string ThreeLetterCode { get; set; }
        public string LanguageName { get; set; }
    }
}
