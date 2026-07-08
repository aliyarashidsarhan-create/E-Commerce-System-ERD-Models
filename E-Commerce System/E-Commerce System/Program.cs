using E_Commerce_System.Model;
using Microsoft.EntityFrameworkCore;

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

            //view all product
            foreach (Product p in context.Products)
            {
                Console.WriteLine($"ID:{p.productId}|{p.productName}|price{p.price}"+
                   $"|stock {p.stockQuantity}|category:{p.Category.categoryName}|Available:{p.isAvailable}" );
            }
                Console.WriteLine("\nProdect Added Successfully!");
            Console.WriteLine("New Prodect Id :" + newProduct.productId);
        }
        //place order
        public static void PlaceOrder()
        {
            Console.WriteLine("\n=== Place New Order ===");
            //display user
            Console.WriteLine("Users:");
            foreach(User u in context.Users)
            {
                Console.WriteLine($"Id:{u.userId}Name:{u.fullName}");
            }
            //choose user

            Console.WriteLine("Enter User Id:");
            int userId=int.Parse(Console.ReadLine());

            //check if user exist
            User user=context.Users.FirstOrDefault(u=>u.userId == userId);

           if(user == null)
            {
                Console.WriteLine("User Not Found ");
                return;
            }

           Console.WriteLine("Enter Shopping address");
            string shopAddress= Console.ReadLine();

            Console.WriteLine("Enter Payment method");
            string payment= Console.ReadLine();

           //create order 

            Order order = new Order
            {
            
                userId=userId,
                User=user,
                orderDate=DateTime.Now,
                totalAmount=0,
                status="Pending",
                shippingAddress=shopAddress,
                paymentMethod=payment

            };


            //add  order 

            context.Orders.Add(order);
            context.SaveChanges();
            //display product

            //loop

        }
        //4- product review
        public static void ProductReview()
        {
            Console.WriteLine("\n=== Product Review ===");

            //user 
            foreach (User u in context.Users)
            { 
                Console.WriteLine($"Id:{u.userId} | Name:{u.fullName}");
            }

            Console.WriteLine("Enter User Id:");
            int userId=int.Parse (Console.ReadLine());

            //serch user
            User user=context.Users.FirstOrDefault (u=>u.userId == userId);
            if (user == null)
            {
                Console.WriteLine("User Not Found");
                return;
            }

            foreach (Product p in context.Products)
            {
                Console.WriteLine($"Id:{p.productId}|name{p.productName}");
            }

            Console.WriteLine("Enter Product Id:");
            int productId=int.Parse (Console.ReadLine());

            Product product=context.Products.FirstOrDefault (u=>u.productId == productId);
            if (product == null)
            {
                Console.WriteLine("product not found ");
                return;
            }

            Console.WriteLine("Enter Rating (1-5)");
            int rate=int.Parse (Console.ReadLine());
            //validate rate

            Console.WriteLine("Enter Comment (Optional)");
            string comment=Console.ReadLine();

            Review review = new Review
            {
                userId=userId,
                User=user,
                productId=productId,
                Product=product,
                rating=rate,
                comment=comment,
                reviewDate=DateTime.Now,

            };
            context.Reviews.Add(review);
           

            context.SaveChanges();

            Console.WriteLine($"Review Added Successfully!:Review Id:{review.reviewId}");


        }

        //5-Update Product Price and Availability
        public static void ProductPriceAndAvailability()
        {
            Console.WriteLine("\n=== Product Price and Availability ===");
            //display all product 

            foreach (Product p in context.Products)
            {
                Console.WriteLine($"Id:{p.productId}|Name:{p.productName}|price:{p.price}");
            }

            Console.WriteLine("Enter Prodect Id");
            int productId= int.Parse (Console.ReadLine());
            //find product
            Product product = context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.WriteLine("product not found");
                return;
            }

            //new price
            Console.Write("Enter New Price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            //update
            product.price = newPrice;
            product.isAvailable = true;

            //save
            context.SaveChanges();

            Console.WriteLine("product updated succedssfuly");
            Console.WriteLine($"ProductId:{product.productId}|NewPrice{product.price} |is available:{product.isAvailable}");
        }
        

        //6-Cancel an Order
        public static void CancelOrder()
        {
            Console.WriteLine("\n=== Cancel an Order ===");

            Console.WriteLine("Enter Order Id");
            int orderId = int.Parse(Console.ReadLine());

            //check if order exist

            Order order = context.Orders.FirstOrDefault(o => o.orderId == orderId);
            if (order == null)
            {
                Console.WriteLine("order not Exist ");
                return;

            }
            if (order.status != "Pending")
            {
                Console.WriteLine("Only pending orders can be cancelled.");
                return;
            }
           //order item

                List<OrderItem> items = context.OrderItems
                                .Where(i => i.orderId == orderId)
                                .ToList();

                foreach (OrderItem i in items)
                {
                    Product product = context.Products
                        .FirstOrDefault(p => p.productId == i.productId);

                   

                    if (product != null)
                    {
                        product.stockQuantity += i.quantity;
                    }



                }
               

                //cancell order 
                order.status = "Cancelled";
                context.SaveChanges();
                Console.WriteLine("'\nOrder cancelled successfully.'");

        }
        

        //7-Delete a Review
        public static void DeleteReview()
        {
            Console.WriteLine("\n=== Delete a Review ===");

            // Display all reviews
            foreach (Review r in context.Reviews) 
            {
                Console.WriteLine($"review I:{r.reviewId}userid:{r.userId}prodectId:{r.productId}");
            }

            Console.WriteLine("Enter Review Id");
            int reviewId= int.Parse (Console.ReadLine());

            //find reviw
            Review review = context.Reviews.FirstOrDefault(r=>r.reviewId == reviewId);
            if(review == null) 
            {
                Console.WriteLine("Review not found");
            }
            //delete Review
            context.Reviews.Remove(review);
            //save 
            context.SaveChanges();

            Console.WriteLine("\nReview deleted successfully.");
        }

        //8 View All Products 
        public static void ViewAllProduct()
        {
            Console.WriteLine("\n=== View All Products  ===");

            // Get all products
            List<Product>products=context.Products.ToList();
            if (products.Count == 0)
            {
                Console.WriteLine("No product found");
            }

                // Display all products
                foreach (Product p in context.Products)
            {
                Console.WriteLine($"Name:{p.productName}|Price:{p.price}|stock:{p.stockQuantity}+" +
                    $"Available :{p.isAvailable}");
            }

            


        }
      
        // 9- Filter Products by Category and Price Range
        public static void FilterProduct()
        {
            Console.WriteLine("\n=== Filter Products by Category and Price Range ===");
            // Display categories

            foreach(Category c in context.Categories)
            {
                Console.WriteLine($"Id:{c.categoryId}|Name:{c.categoryName}");
            }

            Console.WriteLine("Enter Category Id");
            int categoryId= int.Parse (Console.ReadLine());

            Console.Write("Enter Minimum Price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Maximum Price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            List<Product>products=context.Products
                .Where(p=>p.categoryId == categoryId && p.price>=minPrice&&p.price<=maxPrice)
                .OrderBy(p=>p.price)
                .ToList();

            if(products.Count == 0)
            {
                Console.Write("No product Found ");
                return;
            }

            Console.Write("Filterd product: ");
            foreach (Product p in products)
            {
                Console.WriteLine($"Id:{p.productId}|Name:{p.productName}| price:{p.price}");
            }

        }

        
        //10Get Category with All Its Products (Include)
        public static void GetCategory()
        {
            Console.WriteLine("\n=== Get Category with All Its Products ===");

            Console.WriteLine("Enter Category Id:");
            int categoryId=int.Parse (Console.ReadLine());

            //load category with it product
            Category category = context.Categories
                              .Include(c=>c.Products)
                              .FirstOrDefault(c=>c.categoryId== categoryId);

            if (category == null)
            {
                Console.WriteLine("category Not Found");
                return;
            }

            //display category details
            Console.WriteLine($"CategoryId:{category.categoryId}Name:{category.categoryName}Description:{category.description}");

            //product in category
            foreach (Product p in category.Products)
            {
                Console.WriteLine($"Id:{p.productId}Name:{p.productName}Price:{p.price}stack:{p.stockQuantity}");
            }
        }
        //11 View Order History 
        public static void ViewOrderHistory()
        {

        }
        //12 Product Summary Report
        public static void ProductSummaryReport()
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

                Console.WriteLine("Select option:");
                int option =int.Parse(Console.ReadLine());

                switch (option)
                { 
                  case 1: RegisterUser();
                  break;
                  case 2: AddNewProduct();
                  break;
                  case 3: PlaceOrder();
                  break;
                  case 4:
                        ProductReview();
                        break;
                  case 5:
                        ProductPriceAndAvailability();
                        break;
                  case 6:
                        CancelOrder();
                        break;
                   case 7:
                        DeleteReview();
                        break;
                   case 8:
                        ViewAllProduct();
                        break;
                   case 9:
                        FilterProduct();
                        break;
                    case 10:
                        GetCategory();
                        break;
                    case 11:
                        ViewOrderHistory();
                        break;
                    case 12:
                        ProductSummaryReport();
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



