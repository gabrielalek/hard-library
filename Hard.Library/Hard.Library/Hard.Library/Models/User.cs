using System;

namespace Hard.Library.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
