using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    class MediumEmployeePromotion 
    {
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        public MediumEmployeePromotion()
        {
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

        public void SortBySalary()
        {
            var sortedEmployees = employees.OrderBy(v => v.Value.Salary).ToDictionary(v => v.Key, v => v.Value);
            PrintAllEmployee(sortedEmployees);
        }

        public void PrintEmployeeDetailsById()
        {
            Console.WriteLine("Enter employee Id for get details");
            if (int.TryParse(Console.ReadLine(), out int id))
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

        public void PrintEmployeeDetailsByName()
        {
            Console.WriteLine("Please enter employee name for get details");
            string name = Console.ReadLine();
            var emp = employees.Where(e => e.Value.Name == name).First().Value;
            if (emp != null)
            {
                Console.WriteLine(emp);
            }
            else Console.WriteLine($"No one employee with {name} name in list!");
        }

        public void PrintAllEmployeeElderThan()
        {
            Console.WriteLine("Please enter employee name for get details");
            string name = Console.ReadLine();
            var employee = employees.Where(e => e.Value.Name == name).First().Value;
            var emp = employees.Where(e => e.Value.Age > employee.Age).ToDictionary(x=> x.Key, x=>x.Value);
            PrintAllEmployee(emp);
        }

        private void PrintAllEmployee(Dictionary<int, Employee> employees)
        {
            foreach (var item in employees.Keys)
            {
                Console.WriteLine("___________________________________\n___________________________________");
                Console.WriteLine(employees[item]);
            }
        }
    }
}
