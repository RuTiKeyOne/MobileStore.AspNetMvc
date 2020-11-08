using MobileStore.Context;
using MobileStore.Models;
using System.Linq;

namespace MobileStore.Data
{
    public static class InitialData
    {
        public static void Initialize(DbContextPhone context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    
                    new Phone
                    {
                        Company = "Apple",
                        Name = "Iphone 12",
                        Price = 750
                    },

                    new Phone
                    {
                        Company = "Samsung",
                        Name = "Galaxy S20",
                        Price = 1200
                    },

                    new Phone
                    {
                        Company = "Google",
                        Name = "Pixel 4A",
                        Price = 350
                    }

                    );
            };

            context.SaveChanges();
        }
    }
}
