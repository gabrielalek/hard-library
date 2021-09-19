using System;

namespace Hard.Library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Author { get; set; }
        public string Editor { get; set; }
    }
}
