namespace Jewelry.Business.Data
{
    #region Usings
    using System;
    #endregion

    public class Price : IComparable
    {
        public Price(double value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public double Value { get; set; }

        public Currency Currency { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Price price)
            {
                return this.Value.CompareTo(price.Value);
            }

            throw new ArgumentException("Parameter is not a Price!");
        }
    }
    public enum Currency
    {
        Dollar,
        Ruble,
        Euro
    }
}
