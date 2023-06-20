using System;

namespace CleanArchitecture.Application.Dto
{
    public class AmountReFundDto
    {
        public int Id { get; set; }

        public int? MemberId { get; set; } //Member ID

        public int? Amount { get; set; }

        public DateTime? Date { get; set; }
    }
}
