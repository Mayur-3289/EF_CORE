using System;
using System.Collections.Generic;

#nullable disable

namespace EmsDbFirst.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
    }
}
