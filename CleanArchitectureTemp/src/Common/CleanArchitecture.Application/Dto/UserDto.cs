﻿namespace CleanArchitecture.Dto
{
    public class UserDto
    {
        public UserDto()
        {

        }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}