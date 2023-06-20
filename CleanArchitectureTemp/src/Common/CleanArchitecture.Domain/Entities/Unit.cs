using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public partial class Unit : AuditableEntity
    {
        public Unit()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? UnitId { get; set; }

        public string UnitName { get; set; }
        public string LanguageCode { get; set; }
        public long? IndicatorId { get; set; }
    }
}
