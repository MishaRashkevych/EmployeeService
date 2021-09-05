using System;
using System.Windows.Input;

namespace EmployeeService
{
    class Program
    {
        static void Main(string[] args)
        {
            //EasyEmployeePromotion employeePromotion = new EasyEmployeePromotion();
            //-----Task Easy 1
            //employeePromotion.GetEmployeeNamesFromInput();
            //-----Task Easy 2
            //employeePromotion.PrintEmployeePositionByName();
            //-----Task Easy 3
            //employeePromotion.OptimazeCollectionCapacity();
            //-----Task Easy 4
            //employeePromotion.PrintOrderedPromotionList();

            //MediumEmployeePromotion mediumEmployeePromotion = new MediumEmployeePromotion();
            //-----Task Medium 1
            //mediumEmployeePromotion.GetEmployeeNamesFromInput();
            //-----Task Medium 2a
            //mediumEmployeePromotion.SortBySalary();
            //-----Task Medium 2b
            //mediumEmployeePromotion.PrintEmployeeDetailsById();
            //-----Task Medium 3
            //mediumEmployeePromotion.PrintEmployeeDetailsByName();
            //-----Task Medium 4
            //mediumEmployeePromotion.PrintAllEmployeeElderThan();

            //-----Task Hard
            HardEmployeePromotion hardEmployeePromotion = new HardEmployeePromotion();
            hardEmployeePromotion.GetMenu();
        }
    }
}
