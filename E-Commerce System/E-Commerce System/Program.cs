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
            //view all user
            foreach(User u in context.Users)
            {
                Console.WriteLine($"Id:{u.userId} | userName:{u.username} Name{u.fullName}"+
                     $"Email:{u.email}");
            }
         Console.WriteLine("\nUser Registered Successfully!");
          


          

        }
        //add new product
        public static void AddNewProduct()
        {
            Console.WriteLine("\n=== Add New Product ===");

            //display category
            List<Category>categories=context.Categories.ToList();
            Console.WriteLine("Available category :");
           
            foreach(Category c in categories) 
            {
                Console.WriteLine($"Id:{c.categoryId}|{c.categoryName}|");
            }


            Console.WriteLine("Enter Category Id");
            int categoryid=int.Parse(Console.ReadLine());

            // Check that the category exists
            Category category =context.Categories.FirstOrDefault(c=>c.categoryId== categoryid);
        
            if(category == null)
            {
                Console.WriteLine("Category Not Found .");
                return;
            }

            Console.WriteLine("Enter product name");
            string productName=Console.ReadLine();

            Console.WriteLine("Enter Description (optonal):");
            string description=Console.ReadLine();

            Console.WriteLine("Enter Price:");
            decimal price =decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter stock quantity:");
            int stock=int.Parse(Console.ReadLine());

            Console.Write("Enter Image URL (optional): ");
            string image = Console.ReadLine();

            Product newProduct = new Product
            {
                productName=productName,
                description=description,
                price=price,
                imageUrl=image,
                stockQuantity=stock,
                categoryId = categoryid,
                createdAt =DateTime.Now,
                isAvailable=true

            };
            context.Products.Add(newProduct);
            context.SaveChanges();

            Console.WriteLine("\nProdect Added Successfully!");
            Console.WriteLine("New Prodect Id :" +newProduct.productId);
        }
        public static void PlaceOrder()
        {


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
                {
                 case1: RegisterUser();
                break;
                   case2: AddNewProduct();
                break;
             case3: PlaceOrder();
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


