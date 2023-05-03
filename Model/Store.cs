using System;
namespace CollectivoCoffeeProj.Model
{
	public class Store
	{
        public List<Employee> Employees { get; set; }
        public string StoreName { get; set; }
        public List<Product> Products { get; set; } //May not be needed


        public Store()
		{
		}
	}
}

