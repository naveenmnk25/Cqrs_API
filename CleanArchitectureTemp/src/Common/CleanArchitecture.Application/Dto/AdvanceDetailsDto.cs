

using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Dto
{
    public class AdvanceDetailsDto
    {
        public string Name { get; set; } 
        public List<AmountGiven> AmountGiven { get; set; } //Member ID
        public List<AmountReFund> AmountReFund { get; set; } //Member ID
    }
}
