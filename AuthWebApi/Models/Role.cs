﻿namespace AuthWebApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<User> Users { get; set; }
    }
}
