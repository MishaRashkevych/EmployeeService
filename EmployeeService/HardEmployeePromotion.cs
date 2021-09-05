using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeService
{
    public class HardEmployeePromotion
    {
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public HardEmployeePromotion()
        {
            employees.Add(1001, new Employee() { Id = 1001, Name = "John", Age = 25, Salary = 1000});
            employees.Add(1002, new Employee() { Id = 1002, Name = "James", Age = 30, Salary = 1000 });
            employees.Add(1003, new Employee() { Id = 1003, Name = "Hankey", Age = 40, Salary = 1000 });
            employees.Add(1004, new Employee() { Id = 1004, Name = "Jack", Age = 50, Salary = 1000 });
        }

        /// <summary>
        /// Create instances of Employee class with data from user input
        /// </summary>
        public void GetEmployeeNamesFromInput()
        {
            Console.WriteLine("Please enter the employee details)");
            do
            {
                Console.WriteLine();
                Employee employee = new Employee();
                employee.TakeEmployeeDetailsFromUser();
                if (employee.Id != null || !employees.ContainsKey(employee.Id))
                {
                    employees.Add(employee.Id, employee);
                }
                else
                {
                    Console.WriteLine($"-- Message -- Promotion list already contain id {employee.Id}");
                }
                Console.WriteLine("Press \"N\" to add new employee or press any key to go on");
            } while (Console.ReadKey().Key == ConsoleKey.N);
        }

        /// <summary>
        /// Edit Employee details from promotion list by Id from user input
        /// </summary>
        public void EditEmployeeDetailsById()
        {
            Console.WriteLine("Enter employee Id for edit details");
            bool flag = int.TryParse(Console.ReadLine(), out int id);
            if (flag)
            {
                Employee employee = null;
                try
                {
                    employee = employees.Where(e => e.Key == id).First().Value;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"-- Message -- No one employee with {id} Id in list!");
                    Console.WriteLine("-- Message -- " + e.Message);
                    return;
                }

                if (employee != null)
                {
                    Console.WriteLine("____________________\n" + employee + "\n____________________");

                    Console.WriteLine("Enter new Name or press 'Enter' to go next");
                    string name = Console.ReadLine();
                    if (name != string.Empty) employee.Name = name;

                    Console.WriteLine("Enter new Age or press 'Enter' to go next");
                    string inpAge = Console.ReadLine();
                    int age = 0;
                    if (inpAge != string.Empty && int.TryParse(inpAge, out age) && age != 0) employee.Age = age;
                    else 
                    if (inpAge != string.Empty || age != 0)
                    {
                        Console.WriteLine("-- Message -- Incorrect input! Age must be an integer value!");
                        return;
                    }
                            
                    Console.WriteLine("Enter new Salary or press 'Enter' to go next");
                    string inpSalary = Console.ReadLine();
                    int salary = 0;
                    if (inpSalary != string.Empty && int.TryParse(inpAge, out salary) && salary != 0) employee.Salary = salary;
                    else if (inpSalary != string.Empty || salary != 0)
                    {
                        Console.WriteLine("-- Message -- Incorrect input! Salary must be an integer value!");
                        return;
                    }
                }
                else Console.WriteLine($"-- Message -- No one employee with {id} Id in list!");
            }
            else Console.WriteLine("-- Message -- Id must be an integer value!");
        }

        /// <summary>
        /// Write to Console Employee details from promotion list by Id from user input
        /// </summary>
        public void PrintEmployeeDetailsById()
        {
            Console.WriteLine("Enter employee Id for get details");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Employee employee = null;
                try
                {
                    employee = employees.Where(e => e.Key == id).First().Value;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"-- Message -- No one employee with {id} Id in list!");
                    Console.WriteLine("-- Message -- " + e.Message);
                    return;
                }
                if (employee != null)
                {
                    Console.WriteLine("__________________");
                    Console.WriteLine(employee);
                    Console.WriteLine("__________________");

                }
                else Console.WriteLine($"-- Message -- No one employee with {id} Id in list!");
            }
            else Console.WriteLine("-- Message -- Id must be an integer value!");
        }

        /// <summary>
        /// Remove Employee from promotion list by Id from user input
        /// </summary>
        public void RemoveEmployeeById()
        {
            Console.WriteLine("Enter employee`s Id for remove:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Are you sure? (Y/N)");
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.Y && employees.Remove(id))
                    Console.WriteLine($"-- Message -- Employee with {id} Id removed from list!");
                else
                    Console.WriteLine($"-- Message -- No one employee with {id} Id in list!");
            }
            else Console.WriteLine("-- Message -- Id must be an integer value!");
        }

        /// <summary>
        /// Write to Console all Employees details from promotion list
        /// </summary>
        private void PrintAllEmployee()
        {
            foreach (var item in employees.Keys)
            {
                Console.WriteLine("___________________________________");
                Console.WriteLine(employees[item]);
                Console.WriteLine("___________________________________");
            }
        }

        /// <summary>
        /// Print promotion list menu in output stream and get actions
        /// </summary>
        public void GetMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("EmployeePromotion Menu \n\n 1) Get all employees details \n 2) Get employee details \n 3) Edit employee details \n 4) Delete employee \n");
                Console.Write("Please enter a number of action: ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("-- Message -- Please enter an integer value! Try again...");
                    Console.Write("Please enter a number of action: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        PrintAllEmployee();
                        break;
                    case 2:
                        Console.Clear();
                        PrintEmployeeDetailsById();
                        break;
                    case 3:
                        Console.Clear();
                        EditEmployeeDetailsById();
                        break;
                    case 4:
                        Console.Clear();
                        RemoveEmployeeById();
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to go to the menu or 'E' to exit...");
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.E)
                {
                    break;
                }
                Console.Clear();
            } while (true);
        }
    }
}
