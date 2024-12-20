﻿namespace AuthWebApi.Models
{
    public class User
    {      
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Roles { get; set; }
    }
}
