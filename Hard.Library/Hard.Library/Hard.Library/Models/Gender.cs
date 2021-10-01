using System;
using System.Collections.Generic;

namespace Hard.Library.Models
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<Book> Books = new List<Book>();
        public Gender() => CreatedAt = DateTime.Now;
    }
}
