using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class AmountGiven
    {
        public int Id { get; set; }

        public int? MemberId { get; set; } //Member ID

        public int? Amount { get; set; }

        public DateTime? Date { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}