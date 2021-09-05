using System;
using System.Windows.Input;

namespace EmployeeService
{
    class Program
    {
        static void Main(string[] args)
        {
            //EasyEmployeePromotion employeePromotion = new EasyEmployeePromotion();
            //employeePromotion.GetEmployeeNamesFromInput();
            //employeePromotion.PrintEmployeePositionByName();
            //employeePromotion.OptimazeCollectionCapacity();
            //employeePromotion.PrintOrderedPromotionList();

            //MediumEmployeePromotion mediumEmployeePromotion = new MediumEmployeePromotion();
            //mediumEmployeePromotion.GetEmployeeNamesFromInput();
            //mediumEmployeePromotion.SortBySalary();
            //mediumEmployeePromotion.PrintEmployeeDetailsById();
            //mediumEmployeePromotion.PrintEmployeeDetailsByName();
            //mediumEmployeePromotion.PrintAllEmployeeElderThan();

            HardEmployeePromotion hardEmployeePromotion = new HardEmployeePromotion();
            hardEmployeePromotion.GetMenu();
        }
    }
}
