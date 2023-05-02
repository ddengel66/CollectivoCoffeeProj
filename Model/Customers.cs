using System;
namespace CollectivoCoffeeProj.Model
{
    public class Customers
    {
        public List<Customer> customers { get; set; }

        public Customers()
        {
            customers = new List<Customer>();
        }

        public Customer Authenticate(string username, string password)
        {
            var c = customers.Where(o => (o.Username == username) && (o.Password == password));

            if (c.Count() > 0)
            {
                return c.First();
            }
            else
            {
                return null;
            }

        }
    

    /*Customer c = customers.Where(o => o.UserName == username).First();

    if (c != null)
    {
        if(c.Password == password)
        {
            return c;

        }
        else
        {
            return null;
        }
    }

    return null;*/

}
}


