using System;
namespace CollectivoCoffeeProj.Model
{
    public class CutomerAppointment
    {
        public Customer customer { get; set; }
        public Appointment appointment { get; set; }

        public CutomerAppointment(Customer c, Appointment a)
        {
            customer = c;
            appointment = a;
        }
    }
}

