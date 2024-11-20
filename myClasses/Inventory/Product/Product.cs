namespace MyClasses
{
    public class Product : Item
    {
        private SupplierInfo _supplier { get; set; }
        public ProductDetails Details { get; private set; }
        public Pricing Price { get; private set; }
        public Stock Stock { get; private set; }

        public Product() : base(0, "NULL", "NULL")
        {
          _supplier = new SupplierInfo(new Name("a", "a"), new ContactInfo(new Email("a", "a", "ada"), new Phone(12, 345, 32435)));
          Details = new ProductDetails(0, new Dimensions(1, 1, 1));
          Price = new Pricing(0);
          Stock = new Stock(0);
        }
        public Product
          (
            int id, string name, string description, SupplierInfo supplier,
            ProductDetails details, Pricing price, Stock stock
          ) : base(id, name, description)
        {
            if (id < 0) throw new ArgumentException("id must be greater or equal to 0.", nameof(id));
            _supplier = supplier;
            Details = details;
            Price = price;
            Stock = stock;
        }

        public override string ToString() => $"ID: {ID}, {Name} ${Price.Value:2F}, {Details.Dimension}";

        public static Product EmptyProduct()
        {
          SupplierInfo supplier = new SupplierInfo(new Name("NoName", "NoName"), new ContactInfo(new Email("noEmail", "noEmail", "no"), new Phone(11, 111, 11111)));
          ProductDetails details = new ProductDetails(0, new Dimensions(1, 1, 1));
          Pricing price = new Pricing(0);
          Stock stock = new Stock(0);
          return new Product(0, "NULL", "NULL", supplier, details, price, stock);
        }
    }
}
