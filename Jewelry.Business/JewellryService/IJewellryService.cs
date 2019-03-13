namespace Jewelry.Business.JewellryService
{
    #region Usings
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion 

    public interface IJewellryService
    {
        IEnumerable<Jewellry> GetJewellries();

        IEnumerable<Jewellry> GetSortedJewellriesByPropertyName(string propertyName);

        IEnumerable<Jewellry> GetFilteredJewellries(string propertyName, params string[] values);

        void ConvertPriceCurrency(Jewellry jewellry, Currency currency);
    }
}
