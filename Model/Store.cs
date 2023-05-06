using System;
using System.Xml.Linq;

namespace CollectivoCoffeeProj.Model
{
	public class Store
	{
        //Getter and Setters
        public List<Employee> EmployeesList { get; set; }
        public string StoreName { get; set; }
        public Employee SelectedEmployee { get; set; }

        //constructor
        public Store(string StoreName)
		{

            this.StoreName = StoreName;
            EmployeesList = new List<Employee>();

        }
        //method to select a random employee from the chosen store
        public Employee GetSelectedEmployee()
        {
                
            Random ran = new Random();
            //counts how many employees are in the list
            Console.WriteLine(EmployeesList.Count);
            //chooses a random number
            int randomIndex = ran.Next(0, EmployeesList.Count);
            //takes the value of random index
            SelectedEmployee = EmployeesList[randomIndex];
            return SelectedEmployee;

            //CollectivoCoffeeProj.Model.Employee
        }
    }
}


