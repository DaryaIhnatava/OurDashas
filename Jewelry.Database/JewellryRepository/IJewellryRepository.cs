using System.Collections.Generic;
using Jewelry.Database.Data;

namespace Jewelry.Database.JewellryRepository
{
    public interface IJewellryRepository
    {
        IEnumerable<Jewellry> GetJewellries();
    }
}
