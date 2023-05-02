using System;
namespace CollectivoCoffeeProj.Model
{
    public class Appointment
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public DateTime date { get; set; }

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}

