using System;
using System.Collections.Generic;

namespace Person.DB
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? Date { get; set; }
    }
}
