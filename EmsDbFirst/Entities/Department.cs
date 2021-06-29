using System;
using System.Collections.Generic;

#nullable disable

namespace EmsDbFirst.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //np
        public virtual ICollection<Employee> Employees { get; set; }

        public override string ToString()
        {
            return $"{DepartmentId}\t{Name}]\t{Location}";
        }
    }
}
