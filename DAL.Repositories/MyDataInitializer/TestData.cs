using DAL.Entities;

namespace DAL.MyDataInitializer
{
    public static class TestData
    {
        public static readonly Product[] products = new Product[] { 
            new Product{ Id = 0, Name = "Карандаш",Price = 100.99m },
            new Product{ Id = 0, Name = "Ручка",Price = 200.99m },
            new Product{ Id = 0, Name = "Тетрадь",Price = 300.99m }
        
        };
    }
}
