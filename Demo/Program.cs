using static System.Net.WebRequestMethods;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Note Session 02
            //List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
            //List<int> EvenNum = ListHealper.Filter(list, ListHealper.IsEven);

            //foreach (int i in EvenNum)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion


            List<Product> catalog = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };
            #region Task 01

            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics"); 
            List<Product> cheaper = SearchProducts(catalog, p => p.Price < 50);
            List<Product> inStock = SearchProducts(catalog, p => p.Stock > 0);
            List<Product> clothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            Console.WriteLine("---Electronics---");
            foreach (var product in electronics)
            {
                Console.WriteLine($"{product.Name}-${product.Price}(Stock: {product.Stock})");
            }


            Console.WriteLine("\n---Under $50---");
            foreach (var product in cheaper)
            {
                Console.WriteLine($"{product.Name}-${product.Price}(Stock: {product.Stock})");
            }


            Console.WriteLine("\n---In Stock---");
            foreach (var product in inStock)
            {
                Console.WriteLine($"{product.Name}-${product.Price}(Stock: {product.Stock})");
            }

            Console.WriteLine("\n---Clothing Under 100---");
            foreach (var product in clothing)
            {
                Console.WriteLine($"{product.Name}-${product.Price}(Stock: {product.Stock})");
            }
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------");


            #region Task 03 3.1
            Console.WriteLine("--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            #endregion

            #region Task 03 3.2
            List<Product> expensive = TransformProducts(catalog, p => p.Price > 100);
            List<Product> enexpensive = TransformProducts(catalog, p => p.Price <= 100);

            Console.WriteLine("\n---Price Labels---");
            foreach (var product in expensive)
            {
                Console.WriteLine($"{product.Name}: Expensive!");
            }
            foreach (var product in enexpensive)
            {
                Console.WriteLine($"{product.Name}: Afforable!");
            }
            #endregion

        }
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (var product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        public static List<Product> TransformProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (var product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        #endregion
        #region Task 03 3.1
        public static void PrintReport(List<Product> products, Action<Product> printProduct)
        {
            foreach (var product in products)
                printProduct(product);
        }
        #endregion

    }
}
