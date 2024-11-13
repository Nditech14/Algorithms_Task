using Core.Entities;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly List<Country> _countries;

        public CountryRepository()
        {
            
            _countries = new List<Country>
        {
             new Country
                {
                    Id = 1,
                    CountryCode = "234",
                    Name = "Nigeria",
                    CountryIso = "NG",
                    CountryDetails = new List<CountryDetail>
                    {
                        new CountryDetail { Id = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
                        new CountryDetail { Id = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
                        new CountryDetail { Id = 3, CountryId = 1, Operator = "9Mobile Nigeria", OperatorCode = "ETN" },
                        new CountryDetail { Id = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" }
                    }
                },
                new Country
                {
                    Id = 2,
                    CountryCode = "233",
                    Name = "Ghana",
                    CountryIso = "GH",
                    CountryDetails = new List<CountryDetail>
                    {
                        new CountryDetail { Id = 5, CountryId = 2, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" },
                        new CountryDetail { Id = 6, CountryId = 2, Operator = "MTN Ghana", OperatorCode = "MTN Ghana" },
                        new CountryDetail { Id = 7, CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo Ghana" }
                    }
                },
                new Country
                {
                    Id = 3,
                    CountryCode = "229",
                    Name = "Benin Republic",
                    CountryIso = "BN",
                    CountryDetails = new List<CountryDetail>
                    {
                        new CountryDetail { Id = 8, CountryId = 3, Operator = "MTN Benin", OperatorCode = "MTN Benin" },
                        new CountryDetail { Id = 9, CountryId = 3, Operator = "Moov Benin", OperatorCode = "Moov Benin" }
                    }
                },
                new Country
                {
                    Id = 4,
                    CountryCode = "225",
                    Name = "Côte d'Ivoire",
                    CountryIso = "CIV",
                    CountryDetails = new List<CountryDetail>
                    {
                        new CountryDetail { Id = 10, CountryId = 4, Operator = "MTN Côte d'Ivoire", OperatorCode = "MTN CIV" }
                     
                    }
                }
           
        };


        }

        public async Task<Country> GetCountryByCodeAsync(string countryCode)
        {
           
            var country = _countries.FirstOrDefault(c => c.CountryCode == countryCode);

            return await Task.FromResult(country);
        }

    }
}