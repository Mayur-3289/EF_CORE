using EmsDbFirst.Models;
using System;
using System.Linq;

namespace EmsDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1 add department,2.list department,3.add employee 4 list employee  5 update employee 6.delete employee 7 exit");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddDepartment();
                            break;
                        case 2:
                            ListDepartment();
                            break;

                        case 3:
                            AddEmployee();
                            break;

                        case 4:
                            ListEmployee();
                            break;
                        case 5:
                           // UpdateEmployee();
                           // break;


                        case 6:
                            DeleteEmployee();
                            break;
                          
                        default:
                            break;
                    }

                }
            } while (true);

        }

        private static void DeleteEmployee()
        {
            ListEmployee();
            Employee newEmp = new Employee();

            Console.WriteLine("Enter Employee id to delete");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int Id))
            {
                newEmp.Number = Id;
                AssignmentDbContext newcontext = new AssignmentDbContext();
                newcontext.Employees.Remove(newEmp);
                int recordsDeleted = newcontext.SaveChanges();
                if (recordsDeleted > 0)
                {
                    Console.WriteLine("Record Deleted successfully");
                }
                else
                {
                    Console.WriteLine("Record did not get deleted");
                }
            }
        }

        //private static void UpdateEmployee()
        //{
        //    using (AssignmentDbContext context=new AssignmentDbContext())
        //    {
        //        var updateemp=context.Employees.First(e=>e.Number)
        //    }
        //}

        private static void ListEmployee()
        {
            using (AssignmentDbContext context = new AssignmentDbContext())
            {
                var list1 = context.Employees.ToList();
                foreach (var emp in list1)
                {
                    Console.WriteLine(emp);

                }
            }

        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();


            Console.WriteLine("enter name");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                newEmployee.Name = input;
                Console.WriteLine("enter salary");
                input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal salary) && salary > 0)
                {
                    newEmployee.Salary = salary;
                    Console.WriteLine("enter commision");
                    input = Console.ReadLine();
                    if (decimal.TryParse(input, out decimal commision) && commision > 0)
                    {
                        Console.WriteLine("enter date of join");
                        input = Console.ReadLine();
                        if (DateTime.TryParse(input, out DateTime doj))
                        {
                            newEmployee.DateOfJoining = doj;
                            Console.WriteLine("enter date of birth");
                            input = Console.ReadLine();
                            if (DateTime.TryParse(input, out DateTime dob) && dob < DateTime.Today)
                            {
                                newEmployee.DateOfBirth = dob;

                                ListDepartment();

                                Console.WriteLine("enter department id");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out int deptId))
                                {
                                    newEmployee.DepartmentNo = deptId;

                                    Console.WriteLine("enter job title");
                                    input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input))
                                    {
                                        newEmployee.JobTitle = input;

                                        Console.WriteLine("employee manager id");
                                        input = Console.ReadLine();
                                        if (int.TryParse(input, out int managerId))
                                        {
                                            newEmployee.ReportingTo = managerId;
                                        }
                                        else
                                        {
                                            newEmployee.ReportingTo = null;
                                        }
                                        using (AssignmentDbContext context = new AssignmentDbContext())
                                        {
                                            context.Employees.Add(newEmployee);
                                            int recordsaffected = context.SaveChanges();
                                            if (recordsaffected > 0)
                                            {
                                                Console.WriteLine("successed");
                                            }
                                            else
                                            {
                                                Console.WriteLine("fail");
                                            }

                                        }
                                    }

                                }

                            }
                        }
                    }

                }
            }


        }


        private static void ListDepartment()
        {
            using (AssignmentDbContext context = new AssignmentDbContext())
            {
                var list = context.Departments.ToList();
                foreach (var dept in list)
                {
                    Console.WriteLine(dept);

                }
            }
           
        }

        static void AddDepartment()
        {
            Department newDept = new Department();
            Console.WriteLine("enter name");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                newDept.Name = input;
                Console.WriteLine("enter location");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    newDept.Location = input;
                    using (AssignmentDbContext context = new AssignmentDbContext())
                    {
                        int deptId = context.Departments.Max(d => d.DepartmentId);
                        newDept.DepartmentId = deptId + 10;
                        context.Departments.Add(newDept);
                        int recordesAffected = context.SaveChanges();
                        if (recordesAffected > 0)
                        {
                            Console.WriteLine("Dept aded successfully");
                        }
                        else
                        {
                            Console.WriteLine("failed");
                        }

                    }
                }

            }



        }
    }
}