using Microsoft.EntityFrameworkCore;

namespace SoftwareSellingCA.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
        {
            /*
            Database.EnsureDeleted();
            Database.EnsureCreated();
            AddUserPassword();
            AddUserHashCode();
            AddCustomerDetails();
            AddProductsAndActivationKeys();*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=199897144;database=caselling;port=3306;",
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivationCodeProductCustomer>()
                .HasOne(apc => apc.Product)
                .WithMany(p => p.ActivationCodes)
                .HasForeignKey(apc => apc.ProductId);

            modelBuilder.Entity<ActivationCodeProductCustomer>()
                .HasOne(apc => apc.CustomerDetails)
                .WithMany()
                .HasForeignKey(apc => apc.CustomerDetailsId);
        }


        public void AddUserHashCode()
        {
            var userHashList = new List<UserPasswordHash>
            {
                new UserPasswordHash { Username = "chris", PasswordHash = "f29fb5e570e0151e3a79264e53ab3b5b98df4a84" },
                new UserPasswordHash { Username = "emily", PasswordHash = "76deabc94033f8211b0ec302ff6c7fbe69443268" },
                new UserPasswordHash { Username = "john", PasswordHash = "31f51faebeaafcb546721a7bd012db57b5434992" },
                new UserPasswordHash { Username = "kelvin", PasswordHash = "c6fd335f0a10320639eb6888deb60863b120d54b" },
                new UserPasswordHash { Username = "lisa", PasswordHash = "c6b478dd5608b43ab6ff212cef8e9968d3aa5ed8" },
                new UserPasswordHash { Username = "sarah", PasswordHash = "9447c4dbc86c3bb33129986f9ad1a669bfd7e8ea" }
            };

            foreach(var userhash in userHashList)
            {
                Add(userhash);
            }

            SaveChanges();
        }

        public void AddUserPassword()
        {
            
            var userPassList = new List<UserPassword>
            {
                new UserPassword { Username = "chris", Password = "chris123" },
                new UserPassword { Username = "emily", Password = "emily123" },
                new UserPassword { Username = "john", Password = "john123" },
                new UserPassword { Username = "kelvin", Password = "kelvin123" },
                new UserPassword { Username = "lisa", Password = "lisa123" },
                new UserPassword { Username = "sarah", Password = "sarah123" }
            };

            foreach(var userpass in userPassList) 
            { 
                Add(userpass);
            }

            SaveChanges();
        }

        public void AddCustomerDetails()
        {
            List<CustomerDetails> customerDetails = new List<CustomerDetails>()
            {
                new CustomerDetails()
                {
                    customername = "kelvin",
                    customerid = "cust1",
                    
                },
                new CustomerDetails
                {
                    customername = "chris",
                    customerid = "cust2",
                    
                },

                new CustomerDetails()
                {
                    customername = "emily",
                    customerid = "cust3",
                     
                },

                new CustomerDetails()
                {
                    customername = "john",
                    customerid = "cust4",
                     
                },

                new CustomerDetails()
                {
                    customername = "lisa",
                    customerid = "cust5",
                     
                },

                new CustomerDetails
                {
                    customername = "sarah",
                    customerid = "cust6",
                    
                }
            };

           foreach(CustomerDetails custD  in customerDetails)
           {
                Add(custD);
           }

           SaveChanges();
        }

        public void AddProductsAndActivationKeys()
        {
            
            var productList = new List<Product>
            {
                new Product { ProductId = "so001", ProductName = "Dota2", Description = "Dota 2 is a multiplayer online battle arena (MOBA) game where players compete in teams to destroy the enemy's base.", Price = 10.2, PhotoPath = "software1.jpg" },
                new Product { ProductId = "so002", ProductName = "Counter-Strike : Global Offensive", Description = "CS:GO is a renowned first-person shooter where players join as terrorists or counter-terrorists in tactical battles.", Price = 20, PhotoPath = "software2.jpg" },
                new Product { ProductId = "so003", ProductName = "Red Dead Redemption-2", Description = "Red Dead Redemption 2 is an epic western-themed action-adventure game set in 1899 America.", Price = 60, PhotoPath = "software3.jpg" },
                new Product { ProductId = "so004", ProductName = "Grand Theft Auto V", Description = "Grand Theft Auto V is a sprawling open-world action-adventure game set in the fictional state of San Andreas.", Price = 40, PhotoPath = "software4.jpg" },
                new Product { ProductId = "so005", ProductName = "Need For Speed", Description = "Need for Speed is a high-octane racing game series known for its intense street racing, customizable cars, and thrilling police pursuits.", Price = 20, PhotoPath = "software5.jpg" },
                new Product { ProductId = "so006", ProductName = "Resident Evil", Description = "Resident Evil is a renowned action survival horror series where players face off against zombies, mutants, and other monstrosities.", Price = 15, PhotoPath = "software6.jpg" },
                new Product { ProductId = "so007", ProductName = "FIFA 22", Description = "FIFA 22 is the latest installment in the popular FIFA soccer (football) video game series.", Price = 25, PhotoPath = "software7.jpg" },
                new Product { ProductId = "so008", ProductName = "PUBG", Description = "PUBG is a battle royale game where players are dropped onto an island and fight to be the last person or team standing.", Price = 10, PhotoPath = "software8.jpg" },
                new Product { ProductId = "so009", ProductName = "Valorant", Description = "Valorant is a tactical first-person shooter game developed by Riot Games.", Price = 35, PhotoPath = "software9.jpg" },
                new Product { ProductId = "so010", ProductName = "League Of Legends", Description = "League of Legends (LoL) is a multiplayer online battle arena (MOBA) game developed and published by Riot Games.", Price = 5, PhotoPath = "software10.jpg" },
                new Product { ProductId = "so011", ProductName = "APEX Legeneds", Description = "Apex Legends is a free-to-play battle royale game developed by Respawn Entertainment and published by Electronic Arts.", Price = 10, PhotoPath = "software11.jpg" },
                new Product { ProductId = "so012", ProductName = "Fornite", Description = "Fornite is a free-to-play battle royale game developed by Epic Games.", Price = 5, PhotoPath = "software12.jpg" }
            };

            foreach(Product product in productList)
            {
                Add(product);
            }

            SaveChanges();
        }

       

        public DbSet<Product> productsData { get; set; }
        public DbSet<CustomerDetails> customerDetailsData { get; set; }

        public DbSet<UserPassword> userPasswordsData { get; set; }

        public DbSet<UserPasswordHash> userPasswordHash { get; set; }

        public DbSet<ActivationCodeProductCustomer> activationCodes { get; set; }
    }
}
