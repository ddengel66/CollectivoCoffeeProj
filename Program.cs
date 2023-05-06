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
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize()
        {

            var c1 = new Customer
            {
                FirstName = "a",
                LastName = "b",
                Username = "a",
                Password = "b"
            };
            /*var c1 = new Customer
            {
                FirstName = "Kambiz",
                LastName = "Saffari",
                Username = "kambiz",
                Password = "1234"
            };*/
            var c2 = new Customer
            {
                FirstName = "Terence",
                LastName = "Ow",
                Username = "terence",
                Password = "2345"
            };
            var a1 = new Appointment();
            var a2 = new Appointment();
            var a3 = new Appointment();

            var ca1 = new CutomerAppointment(c1, a1);
            var ca2 = new CutomerAppointment(c1, a2);
            var ca3 = new CutomerAppointment(c2, a3);

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            appointments = new List<Appointment>();
            appointments.Add(a1);
            appointments.Add(a2);
            appointments.Add(a3);

            customerAppointments = new List<CutomerAppointment>();
            customerAppointments.Add(ca1);
            customerAppointments.Add(ca2);
            customerAppointments.Add(ca3);

            var emp1 = new Employee("Klemens");
            var emp2 = new Employee("Garrix");
            var emp3 = new Employee("Kaitlyn");
            var emp4 = new Employee("Annie");
            var emp5 = new Employee("Dawson");
            var emp6 = new Employee("Pepper");


            var store1 = new Store("Milwaukee");
            var store2 = new Store("Chicago");
            var store3 = new Store("Naperville");

            store1.EmployeesList.Add(emp1);
            store1.EmployeesList.Add(emp2);

            store2.EmployeesList.Add(emp3);
            store2.EmployeesList.Add(emp4);

            store3.EmployeesList.Add(emp5);
            store3.EmployeesList.Add(emp6);

            stores = new List<Store>();

            stores.Add(store1);
            stores.Add(store2);
            stores.Add(store3);

        }
        static void Menu()
        {
            bool done = false;
            //done = false;

            while (!done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Order: 5 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
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
            if (authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(username, password);
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
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }



        static void GetCurrentAppointmentsMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }


            var appointmentList = customerAppointments.Where(o => o.customer.Username == authenticatedCustomer.Username);

            if (appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
            {
                foreach (var appointmnet in appointmentList)
                {
                    Console.WriteLine(appointmnet.appointment.date);
                }
            }

        }


        static void ChooseStore()
        {
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You must login to order");
                return;
            }


            Console.WriteLine("Options: Milwaukee: 1 --- Chicago: 2 --- Naperville: 3 --- Go Back to Menu: q ---");
            Console.WriteLine("Select Store");
            string storeChoice = Console.ReadLine();

            //string StoreName = " ";

            switch (storeChoice)
            {
                case "1":
                    //StoreName = "Milwaukee";

                    store = stores[0];
                    Employee selectedEmployee = store.GetSelectedEmployee();
                    Console.WriteLine("Selected employee: " + selectedEmployee.EmpName);
                    ChooseProducts(selectedEmployee,store);


                    break;

                case "2":
                    //StoreName = "Chicago";
                    store = stores[1];
                    selectedEmployee = store.GetSelectedEmployee();
                    Console.WriteLine("Selected employee: " + selectedEmployee.EmpName);
                    ChooseProducts(selectedEmployee, store);
                    break;

                case "3":
                    //StoreName = "Naperville";
                    store = stores[2];
                    selectedEmployee = store.GetSelectedEmployee();
                    Console.WriteLine("Selected employee: " + selectedEmployee.EmpName);
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


        /*static void ChooseProducts(Employee selectedEmployee,Store store)
        {

            Console.WriteLine("Drink Options: Coffee: 1 --- Water: 2 --- Tea: 3 --- ");
            Console.WriteLine("Food Options: Muffin: a --- Bagel: b --- Croissant: c --- Go Back to Menu: q ---");
            Console.WriteLine("Select Desired Items from Menu");
            string ProductChoice = Console.ReadLine();
            string ProductName = " ";
            switch (ProductChoice)
            {
                case "1":
                    ProductName = "Coffee";
                    break;

                case "2":
                    ProductName = "Water";
                    break;

                case "3":
                    ProductName = "Teas";
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

            }*/
            static void ChooseProducts(Employee selectedEmployee, Store store)
            {
                // Get the store location and employee
                // Store SelectedStore = new Store(); needs to be written in with the store selection and employee randomization along with the 
                //next two lines 
                /*string StoreName = SelectedStore.GetName();
                Employee SelectedEmployee = SelectedStore.GetSelectedEmployee();*/

                // Display the menu options
                Console.WriteLine("Drink Options: Coffee: 1 --- Water: 2 --- Tea: 3 --- ");
                Console.WriteLine("Food Options: Muffin: a --- Bagel: b --- Croissant: c --- Go Back to Menu: q ---");
                Console.WriteLine("Select Desired Items from Menu");

                
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
                Console.WriteLine("RECEIPT");
                Console.WriteLine("--------");
                Console.WriteLine($"Store: {store.StoreName}"); //
                Console.WriteLine("Prepared by: " + selectedEmployee.EmpName);        // Console.WriteLine($"Employee: {SelectedEmployee.GetName()}"); //the employee selection needs to be fixed for this line
                Console.WriteLine($"Product: {ProductName}");
                Console.WriteLine("--------");

                // Wait for user input before returning to the menu
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Return to the menu
                Menu();
            }



        }






        /*public void PrintReceipt()
        {
            Console.WriteLine("Receipt: ");
            Console.WriteLine("Store: ");
            Console.WriteLine("Employee: ");
            Console.WriteLine("Product: ");

        }*/
    }
