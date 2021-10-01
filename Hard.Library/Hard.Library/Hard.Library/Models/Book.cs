using System;
using System.Collections.Generic;

namespace Hard.Library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Editor { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Gender> Genders = new List<Gender>();
        public DateTime LastUpdate { get; set; }
        public Book() => CreatedAt = DateTime.Now;
    }
}
