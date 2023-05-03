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

            //EmployeesList = new List<Employee>();

            EmployeesList = new List<Employee>();

            if (StoreName == "Milwaukee")
            {
                EmployeesList.Add(new Employee("Klemens"));
                EmployeesList.Add(new Employee("Garrix"));
            }
            else if(StoreName == "Chicago")
            {
                EmployeesList.Add(new Employee("Kaitlyn"));
                EmployeesList.Add(new Employee("Annie"));
            }

            else if(StoreName == "Naperville")
            {
                EmployeesList.Add(new Employee("Dawson"));
                EmployeesList.Add(new Employee("Pepper"));
            }

            Random ran = new Random();
            int randomIndex = ran.Next(0, EmployeesList.Count);
            SelectedEmployee = EmployeesList[randomIndex];

        }
    }
}


