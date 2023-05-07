using System;
namespace CollectivoCoffeeProj.Model
{
    public class Customer
    {
        //getters and setters
        private static int autoIncreament;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //customer constructor
        public Customer()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}

