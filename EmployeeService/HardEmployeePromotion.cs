using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine($"Promotion list already contain id {employee.Id}");
                }
                Console.WriteLine("Press \"N\" to add new employee or press any key to go on");
            } while (Console.ReadKey().Key == ConsoleKey.N);
        }

        public void EditEmployeeDetailsById()
        {
            Console.WriteLine("Enter employee Id for edit details");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var emp = employees.Where(e => e.Key == id).First().Value;
                if (emp != null)
                {
                    PrintEmployeeDetailsById(id);

                    Console.WriteLine("Enter new name or press 'Enter' to go next");
                    string name = Console.ReadLine();
                    if (name != string.Empty) emp.Name = name;

                    Console.WriteLine("Enter new Age or press 'Enter' to go next");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age != 0) emp.Age = age;

                    Console.WriteLine("Enter new Age or press 'Enter' to go next");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    emp.Salary = salary;
                }
                else Console.WriteLine($"No one employee with {id} Id in list!");
            }
            else Console.WriteLine("Id must be an integer value!");
        }

        public void PrintEmployeeDetailsById(int id = 0)
        {
            Console.WriteLine("Enter employee Id for get details");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var emp = employees.Where(e => e.Key == id).First().Value;
                if (emp != null)
                {
                    Console.WriteLine(emp);
                }
                else Console.WriteLine($"No one employee with {id} Id in list!");
            }
            else Console.WriteLine("Id must be an integer value!");
        }

        public void RemoveEmployeeById()
        {
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Are you sure");
                if (employees.Remove(id))
                    Console.WriteLine($"Employee with {id} Id removed from list!");
                else
                    Console.WriteLine($"No one employee with {id} Id in list!");
            }
            else Console.WriteLine("Id must be an integer value!");
        }

        private void PrintAllEmployee()
        {
            foreach (var item in employees.Keys)
            {
                Console.WriteLine("___________________________________");
                Console.WriteLine(employees[item]);
                Console.WriteLine("___________________________________");
            }
        }

        public void GetMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("EmployeePromotion Menu \n\n 1) Get all employees details \n 2) Get employee details \n 3) Edit employee details \n 4) Delete employee \n");
                Console.Write("Please enter a number of action: ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter an integer value! Try again...");
                }

                switch (choice)
                {
                    case 1:
                        PrintAllEmployee();

                        break;
                    case 2:
                        PrintEmployeeDetailsById();
                        break;
                    case 3:
                        EditEmployeeDetailsById();
                        break;
                    case 4:
                        RemoveEmployeeById();
                        break;
                    default:
                        break;
                }
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
