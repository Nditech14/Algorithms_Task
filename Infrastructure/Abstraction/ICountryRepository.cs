using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryByCodeAsync(string countryCode);
    }
}
