using E_Commerce_System.Model;

namespace E_Commerce_System
{
   public class Program
    {
        public static ECommerceContext context = new ECommerceContext();
     

        
        //Add user
        public static void RegisterUser()
        {
            Console.WriteLine("\n=== Register New User ===");
            Console.WriteLine("Enter User Name");
            string userName=Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            //store password
            string passwordHash = password;

            Console.WriteLine("Enter Full Name");
            string fullName=Console.ReadLine();

            Console.WriteLine("Enter phone Number(optional)");
            string phone=Console.ReadLine();

            Console.WriteLine("Enter Address (optional)");
            string address=Console.ReadLine();



            User newUser = new User

            {
                username = userName,
                email =email,
                passwordHash=password,
  
                fullName=fullName,

               phoneNumber =phone,
                address =address,
                registrationDate =DateTime.Now,
                isActive =true

            };
            context.Users.Add(newUser);
            //save change
            context.SaveChanges();

            Console.WriteLine("\nUser Registered Successfully!");
            Console.WriteLine("New user Id :"+newUser.userId);


          

        }
        public static void AddNewProduct()
        {
            Console.WriteLine("\n=== Add New Product ===");

        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("        E-Commerce System");
                Console.WriteLine("========================================");
                Console.WriteLine("1-Register a New User");
                Console.WriteLine("2-Add a New Product to a Category");
                Console.WriteLine("3-Place an Order");
                Console.WriteLine("4-Write a Product Review");
                Console.WriteLine("5-Update Product Price and Availability");
                Console.WriteLine("6-Cancel an Order");
                Console.WriteLine("7-Delete a Review");
                Console.WriteLine("8- View All Products");
                Console.WriteLine("9-Filter Products by Category and Price Range");
                Console.WriteLine("10-Get Category with All Its Products");
                Console.WriteLine("11- View Order History with Full Details");
                Console.WriteLine("12- Product Summary Report");
                Console.WriteLine(" 0  - Exit");

                Console.WriteLine("Select option");
                int option =int.Parse(Console.ReadLine());

                switch(option)
                { }
            case1: RegisterUser();
                break;
                   case2: AddNewProduct();
                break;
                 case 0:
                    exit = true;
                    break;

                default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
                }

                if(!exit)
                {
                    Console.WriteLine("\nPress any key to contenue..");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("GoodBy !");
        }
        }
}


