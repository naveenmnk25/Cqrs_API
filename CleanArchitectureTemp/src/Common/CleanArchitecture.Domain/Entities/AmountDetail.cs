using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class AmountDetail
    {
        public int Id { get; set; }

        public int? RoomRent { get; set; }

        public int? Advance { get; set; }

        public int? Dedection { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}