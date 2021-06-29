using System;
using System.Collections.Generic;

#nullable disable

namespace EmsDbFirst.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseReportingToNavigation = new HashSet<Employee>();
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal Commission { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentNo { get; set; }
        public string JobTitle { get; set; }
        public int? ReportingTo { get; set; }
        public bool? IsActive { get; set; } = true;

        //navigation properties

        public virtual Department DepartmentNoNavigation { get; set; }
        public virtual Employee ReportingToNavigation { get; set; }
        public virtual ICollection<Employee> InverseReportingToNavigation { get; set; }

        public override string ToString()
        {
            return $"{Number}\t{Name}]\t{Salary}\t{Commission}\t{DateOfJoining}\t{DateOfBirth}\t{DepartmentNo}\t{JobTitle}\t{ReportingTo}";
        }
    }
}
