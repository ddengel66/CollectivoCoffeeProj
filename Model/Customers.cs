using System;
namespace CollectivoCoffeeProj.Model
{
    public class Customers
    {
        //getters and setters
        public List<Customer> customers { get; set; }

        //constructor
        public Customers()
        {
            customers = new List<Customer>();
        }

        public Customer Authenticate(string username, string password)
        {
            //finding any customer whose username and password matches the given input
            var c = customers.Where(o => (o.Username == username) && (o.Password == password));

            // If there is at least one matching customer return the first one found
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


