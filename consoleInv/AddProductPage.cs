using MyClasses;

namespace consoleInv
{
    public class AddProductPage
    {
        private DbManager _dbManager;

        public AddProductPage()
        {
            _dbManager = new DbManager(Path.Combine(Directory.GetCurrentDirectory(), "DataBase.db"));
        }

        public void Display()
        {
            Console.Clear();
            List<Product> products = _dbManager.GetProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products to display.");
                return;
            }
            int maxProductNameLength = products.Max(product => product.Name.Length);
            int maxDescriptionLength = products.Max(product => product.Description.Length);
            int maxStockQuantityLength = products.Max(product => product.Stock.StockQuantity.ToString().Length);
            int maxPriceLength = products.Max(product => product.Price.Value.ToString().Length);
            int maxWeightLength = products.Max(product => product.Details.Weight.ToString().Length);
            int maxDimensionLength = products.Max(product => product.Details.Dimension.ToString().Length);
            int boxWidth = Math.Max(50, "ID".Length + maxProductNameLength + maxDescriptionLength + maxStockQuantityLength + maxPriceLength + maxWeightLength + maxDimensionLength + 15);
            string format = $"| {{0,-5}} | {{1,-{maxProductNameLength}}} | {{2,-{maxDescriptionLength}}} | {{3,-{maxStockQuantityLength}}} | {{4,-{maxPriceLength}}} | {{5,-{maxWeightLength}}} | {{6,-{maxDimensionLength}}} |";

            Console.WriteLine(new string('-', boxWidth));
            Console.WriteLine(format, "ID", "Name", "Description", "Stock", "Price", "Weight", "Dimensions");
            Console.WriteLine(new string('-', boxWidth));

            foreach (Product product in products)
                Console.WriteLine(format, product.ID, product.Name, product.Description, product.Stock.StockQuantity.ToString(), product.Price.Value.ToString(), product.Details.Weight.ToString(), product.Details.Dimension.ToString());

            Console.WriteLine(new string('-', boxWidth));
            Console.ReadLine();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Product ===");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            Console.Write("Enter product description: ");
            string description = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Product description cannot be empty.");
                return;
            }

            Console.Write("Enter stock quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stockQuantity) || stockQuantity < 0)
            {
                Console.WriteLine("Invalid stock quantity. Must be a non-negative integer.");
                return;
            }

            Console.Write("Enter product price: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
            {
                Console.WriteLine("Invalid price. Must be a non-negative number.");
                return;
            }

            Console.Write("Enter product stock amount: ");
            if (!double.TryParse(Console.ReadLine(), out double stockAmount) || stockAmount < 0)
            {
                Console.WriteLine("Invalid stock amount. Must be a non-negative number.");
                return;
            }

            Console.Write("Enter product weight (in kg): ");
            if (!double.TryParse(Console.ReadLine(), out double weight) || weight < 0)
            {
                Console.WriteLine("Invalid weight. Must be a non-negative number.");
                return;
            }

            Console.Write("Enter product dimensions (e.g., 10.0x20.3x30.87): ");
            string dimensions = Console.ReadLine()?.Trim() ?? "";
            string[] dimensionStrings = dimensions.Split('x');
            if (dimensionStrings.Length != 3)
                throw new ArgumentException("Invalid dimensions format. Expected format: 'LxWxH'.");

            double[] productDimensions = dimensionStrings
                .Select(part => double.Parse(part.Trim()))
                .ToArray();
            if (string.IsNullOrEmpty(dimensions))
            {
                Console.WriteLine("Product dimensions cannot be empty.");
                return;
            }

            Console.Write("Enter supplier first name: ");
            string supplierFirstName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(supplierFirstName))
            {
                Console.WriteLine("Supplier first name cannot be empty.");
                return;
            }

            Console.Write("Enter supplier last name: ");
            string supplierLastName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(supplierLastName))
            {
                Console.WriteLine("Supplier last name cannot be empty.");
                return;
            }

            Console.Write("Enter supplier email: ");
            string supplierEmail = Console.ReadLine().Trim() ?? "";
            if (string.IsNullOrEmpty(supplierEmail))
            {
                Console.WriteLine("Supplier email cannot be empty.");
                return;
            }

            Console.Write("Enter supplier phone number: ");
            string supplierPhone = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(supplierEmail))
            {
                Console.WriteLine("Supplier phone number cannot be empty.");
                return;
            }

            ContactInfo supplierContact = new ContactInfo(Email.FromString(supplierEmail), Phone.FromString(supplierPhone));
            SupplierInfo info = new SupplierInfo(new Name(supplierFirstName, supplierLastName), supplierContact);
            ProductDetails details = new ProductDetails(weight, new Dimensions(productDimensions[0], productDimensions[1], productDimensions[2]));
            Pricing pricing = new Pricing((decimal)price);
            Stock stock = new Stock(stockQuantity);
            Product product = new Product(0, name, description, info, details, pricing, stock);

            if (_dbManager.AddProduct(product))
            {
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add product.");
            }

            Console.WriteLine("Press any key to return to the previous menu...");
            Console.ReadKey();
        }
    }
}
