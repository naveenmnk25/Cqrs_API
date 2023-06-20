using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? PhoneNo { get; set; }

        public string Company { get; set; }

        public bool? IsVecated { get; set; }

        public bool IsFood { get; set; }

        public DateTime? JoiningDate { get; set; }

        public DateTime? VecateDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}