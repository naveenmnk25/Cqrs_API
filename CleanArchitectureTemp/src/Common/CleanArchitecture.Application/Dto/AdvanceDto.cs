using System;

namespace CleanArchitecture.Application.Dto
{
    public class AdvanceDto
    {
        public int MemberId { get; set; } //Member ID
        public string Name { get; set; } //Member ID

        public int TGivenAmount { get; set; }
        public int TReFundAmount { get; set; }

        public DateTime? Date { get; set; }
    }
}
