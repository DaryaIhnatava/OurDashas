namespace Jewelry.Database.Data
{
    public class Price
    {
        public Price(double value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        private double value;


        public double Value
        {
            get => value;
            set
            {
                if (value > 0)
                    this.value = value;
            }
        }
        public Currency Currency { get; set; }
    }

    public enum Currency
    {
        Dollar,
        Ruble,
        Euro
    }
}
