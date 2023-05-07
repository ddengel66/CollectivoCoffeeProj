using System;
namespace CollectivoCoffeeProj.Model
{
    public class CutomerAppointment
    {
        //Getters and Setters
        public Customer customer { get; set; }
        public Appointment appointment { get; set; }

        //constructor
        public CutomerAppointment(Customer c, Appointment a)
        {
            customer = c;
            appointment = a;
        }
    }
}

