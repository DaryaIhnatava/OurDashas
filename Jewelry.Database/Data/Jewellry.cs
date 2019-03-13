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

        public string Shape { get; private set; }

        public string Metal { get; private set; }

        public string Brand { get; private set; }

        public Price Price { get; set; }
    }
}
