﻿using System;

namespace CleanArchitecture.Application.Dto
{
    public class MemberDto
    {
        public string? Name { get; set; }
        public double? PhoneNo { get; set; }
        public string? Company { get; set; }
        public bool IsVecated { get; set; }
        public bool IsFood { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime VecateDate { get; set; }
    }
}
