using System;
using System.Xml.Linq;

namespace CollectivoCoffeeProj.Model
{
	public class Store
	{
        public List<Employee> EmployeesList { get; set; }
        public string StoreName { get; set; }
        public List<Product> Products { get; set; } //May not be needed

        public Employee SelectedEmployee { get; set; }


        public Store(string StoreName)
		{

            this.StoreName = StoreName;
            EmployeesList = new List<Employee>();

        }

        public Employee GetSelectedEmployee()
        {
                
            Random ran = new Random();
            Console.WriteLine(EmployeesList.Count);
            int randomIndex = ran.Next(0, EmployeesList.Count);
            SelectedEmployee = EmployeesList[randomIndex];
            return SelectedEmployee;

            //CollectivoCoffeeProj.Model.Employee
        }
    }
}


