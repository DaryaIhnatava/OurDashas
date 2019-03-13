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
            Price price = obj as Price;
            if (price != null)
            {
                return this.Value.CompareTo(price.Value);
            }
            else
            {
                //It is bad to return throwing exceptions, but there it should be I think
                throw new ArgumentException("Parameter is not a Price!");
            }
        }
    }
    public enum Currency
    {
        Dollar,
        Ruble,
        Euro
    }
}
