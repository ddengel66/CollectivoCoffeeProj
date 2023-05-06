using System;
namespace CollectivoCoffeeProj.Model
{
    public class Appointment
    {
        //initialize variable
        private static int autoIncreament;

        //Getters and Setters
        public int Id { get; set; }
        public DateTime date { get; set; }

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}

