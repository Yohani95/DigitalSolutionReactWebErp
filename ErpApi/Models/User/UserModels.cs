﻿
namespace Models.User
{
    public class UserModels
    {
        public int Id { get; set; }
        public string rut { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int jobPosition { get; set; }
        public byte[] Foto { get; set; }
        public string Nombrefoto { get; set; }
    }
}