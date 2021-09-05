using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeService
{
    class EasyEmployeePromotion
    {
        List<Employee> employees = new List<Employee>();

        public EasyEmployeePromotion()
        {
        }

        /// <summary>
        /// Create instances of Employee class with data from user input
        /// </summary>
        public void GetEmployeeNamesFromInput()
        {
            Console.WriteLine("Please enter the employee names in the order of their eligibility \nfor promotion(Please enter blank to stop)");
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "blank") break;
                Employee employee = new Employee();
                employee.Name = input;
                employees.Add(employee);
            }
            PrintAllEmployee(employees);
        }

        /// <summary>
        /// Print Employee`s position in promotion list by Name from user input
        /// </summary>
        public void PrintEmployeePositionByName()
        {
            Console.WriteLine("Please enter the name of the employee to check promotion position:");
            string input = Console.ReadLine();
            Employee employee = employees.Find(e => e.Name == input);
            if (employee!=null) Console.WriteLine($"\"{input} is at the position {employees.IndexOf(employee)} for promotion");
            else Console.WriteLine($"{input} employee is not on the promotion list");
        }

        /// <summary>
        /// Optimize the capacity to the actual number of elements in employee collection,
        //     if that number is less than a threshold value.
        /// </summary>
        public void OptimizeCollectionCapacity()
        {
            Console.WriteLine($"The current size of the collection is {employees.Capacity}");
            employees.TrimExcess();
            Console.WriteLine($"TThe size after removing the extra space is {employees.Capacity}");
        }

        /// <summary>
        /// Ordered promotion list by Name and print it.
        /// </summary>
        public void PrintOrderedPromotionList()
        {
            IEnumerable<Employee> orderedEmployees = employees.OrderBy(e => e.Name);
            PrintAllEmployee(orderedEmployees);
        }

        /// <summary>
        /// Write to Console all Employees details from promotion list
        /// </summary>
        public void PrintAllEmployee(IEnumerable<Employee> employees)
        {
            Console.WriteLine("Promoted employee list:");
            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
