namespace Jewelry.Database.Data
{
    public class Jewellry
    {
        public Jewellry(string shape, string metal, string brand, double price, Currency currency)
        {
            Shape = shape;
            Metal = metal;
            Brand = brand;
            Price = new Price(price, currency);
        }

        public string Shape { get; }

        public string Metal { get; }

        public string Brand { get; }

        public Price Price { get; set; }
    }
}
