using System;
namespace CollectivoCoffeeProj.Model
{
	public class Customer
	{
        private static int autoIncrement;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }


        public Customer()
        {


            autoIncrement++;

            Id = autoIncrement;


        }
    }
}

