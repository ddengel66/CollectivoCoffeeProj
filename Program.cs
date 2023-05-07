using System.Security.Cryptography.X509Certificates;
using CollectivoCoffeeProj.Model;

namespace CollectivoCoffeeProj
{
    public class Program
    {
        private static Customers customers;
        private static List<Appointment> appointments;
        private static List<CutomerAppointment> customerAppointments;
        private static Customer authenticatedCustomer;
        private static Customer customer;
        static Store store;

        private static List<Store> stores;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Collectivo Coffee!");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            //Create new instances of Customer class
            var c1 = new Customer
            {
                FirstName = "Kambiz",
                LastName = "Saffari",
                Username = "kambiz",
                Password = "1234"
            };
            var c2 = new Customer
            {
                FirstName = "Terence",
                LastName = "Ow",
                Username = "terence",
                Password = "2345"
            };

            //Create new instances of Appointment class
            var a1 = new Appointment();
            var a2 = new Appointment();
            var a3 = new Appointment();

            //Create new instances of Customer Appointment by passing a customert and appointment
            var ca1 = new CutomerAppointment(c1, a1);
            var ca2 = new CutomerAppointment(c1, a2);
            var ca3 = new CutomerAppointment(c2, a3);

            //Create new instance of Customers class and add customers to its list
            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            //Create a list of appointments and add appointments to it
            appointments = new List<Appointment>();
            appointments.Add(a1);
            appointments.Add(a2);
            appointments.Add(a3);

            // Create a list of customer appointments and add customer appointments to it
            customerAppointments = new List<CutomerAppointment>();
            customerAppointments.Add(ca1);
            customerAppointments.Add(ca2);
            customerAppointments.Add(ca3);

            //Create new instances of Employee class
            var emp1 = new Employee("Klemens");
            var emp2 = new Employee("Garrix");
            var emp3 = new Employee("Kaitlyn");
            var emp4 = new Employee("Annie");
            var emp5 = new Employee("Dawson");
            var emp6 = new Employee("Pepper");

            // Create new instances of Store class
            var store1 = new Store("Milwaukee");
            var store2 = new Store("Chicago");
            var store3 = new Store("Naperville");

            //Adding employees to store list
            store1.EmployeesList.Add(emp1);
            store1.EmployeesList.Add(emp2);

            store2.EmployeesList.Add(emp3);
            store2.EmployeesList.Add(emp4);

            store3.EmployeesList.Add(emp5);
            store3.EmployeesList.Add(emp6);

            //create list of stores and adding stores to them
            stores = new List<Store>();
            stores.Add(store1);
            stores.Add(store2);
            stores.Add(store3);

        }
        static void Menu()
        {
            //initialized variable for t/f
            bool done = false;

            while (!done)
            {
                //Prompts user to enter choice 
                Console.WriteLine("\nOptions: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Order: 5 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                //switch case that gives access to all methods
                switch (choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;

                    //new case with new order method
                    case "5":
                        ChooseStore();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            Console.Clear();
            //if statement making sure its not empty
            if (authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                //Sending it to method in different class to confirm credentials match
                authenticatedCustomer = customers.Authenticate(username, password);
                Console.Write('\n');
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("invalid username or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
            }
            
        }



        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!");
        }


        static void SignUpMenu()
        {
            //Prompts user to enter information
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            //Create new instance of customer class
            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            //add customer to list
            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }



        static void GetCurrentAppointmentsMenu()
        {
            //checks if statement is true
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }

            //get the list of appointments for the authenticated customer
            var appointmentList = customerAppointments.Where(o => o.customer.Username == authenticatedCustomer.Username);


            //if the appointment list is empty it will display a message
            if (appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
            {
                //display dates
                foreach (var appointmnet in appointmentList)
                {
                    Console.WriteLine(appointmnet.appointment.date);
                }
            }

        }


        static void ChooseStore()
        {
            //checks if statement is true
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You must login to order");
                return;
            }

            Console.Clear();
            //display store options
            Console.WriteLine("Options: Milwaukee: 1 --- Chicago: 2 --- Naperville: 3 --- Go Back to Menu: q ---");
            Console.Write("Select Store: ");
            string storeChoice = Console.ReadLine();

            
            switch (storeChoice)
            {
                case "1":

                    //select store in first index of list
                    store = stores[0];
                    //method to retrieve the currently selected employee and assigns it to variable.
                    Employee selectedEmployee = store.GetSelectedEmployee();
                    //Sends results to ChooseProduct method
                    ChooseProducts(selectedEmployee,store);


                    break;

                case "2":

                    //select store in first index of list
                    store = stores[1];
                    //method to retrieve the currently selected employee and assigns it to variable.
                    selectedEmployee = store.GetSelectedEmployee();
                    //Sends results to ChooseProduct method
                    ChooseProducts(selectedEmployee, store);
                    break;

                case "3":

                    //select store in first index of list
                    store = stores[2];
                    //method to retrieve the currently selected employee and assigns it to variable.
                    selectedEmployee = store.GetSelectedEmployee();
                    //Sends results to ChooseProduct method
                    ChooseProducts(selectedEmployee, store);

                    break;

                case "q":
                    Menu();
                    break;

                default:
                    Console.WriteLine("Invalid command!");
                    break;

            }


        }


            static void ChooseProducts(Employee selectedEmployee, Store store)
            {

                Console.Clear();

                // Display the menu options
                Console.WriteLine("Drink Options: Coffee: 1 --- Water: 2 --- Tea: 3 --- ");
                Console.WriteLine("Food Options: Muffin: a --- Bagel: b --- Croissant: c --- Go Back to Menu: q ---");
                Console.WriteLine("\nSelect Desired Items from Menu");

                
                // Prompt the user for their selection
                string ProductChoice = "";
                while (ProductChoice != "1" && ProductChoice != "2" && ProductChoice != "3" &&
                       ProductChoice != "a" && ProductChoice != "b" && ProductChoice != "c" &&
                       ProductChoice != "q")
                {
                    Console.Write("Enter your choice: ");
                    ProductChoice = Console.ReadLine();
                }

                // Process the user's selection
                string ProductName = "";
                switch (ProductChoice)
                {
                    case "1":
                        ProductName = "Coffee";
                        break;

                    case "2":
                        ProductName = "Water";
                        break;

                    case "3":
                        ProductName = "Tea";
                        break;

                    case "a":
                        ProductName = "Muffin";
                        break;

                    case "b":
                        ProductName = "Bagel";
                        break;

                    case "c":
                        ProductName = "Croissant";
                        break;

                    case "q":
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                // Print the receipt
                Console.Clear();
                Console.WriteLine("\nRECEIPT");
                Console.WriteLine("-----------------");
                Console.WriteLine($"Store: {store.StoreName}"); 
                Console.WriteLine("Prepared by: " + selectedEmployee.EmpName);                                            
                Console.WriteLine($"Product: {ProductName}");
                Console.WriteLine("-----------------");

                // Wait for user input before returning to the menu
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                // Return to the menu
                Menu();
            }


        }

    }
