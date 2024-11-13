using Application.Dtos;
using Application.Interfaces;
using Application.Log;
using Infrastructure.Abstraction;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILoggerService<CountryService> _logger;

        public CountryService(ICountryRepository countryRepository, ILoggerService<CountryService> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<APIResponse<PhoneNumberResponseDto>> GetCountryByPhoneNumberAsync(string phoneNumber)
        {
            _logger.LogInfo("Received phone number: {PhoneNumber}", phoneNumber);

            var countryCode = ExtractCountryCode(phoneNumber);
            if (countryCode == null)
            {
                _logger.LogError(null, "Invalid country code in phone number: {PhoneNumber}", phoneNumber);
                return new APIResponse<PhoneNumberResponseDto>("Invalid country code in phone number", 400);
            }

            var country = await _countryRepository.GetCountryByCodeAsync(countryCode);
            if (country == null)
            {
                _logger.LogError(null, "Country not found for code: {CountryCode}", countryCode);
                return new APIResponse<PhoneNumberResponseDto>("Country not found for the provided phone number", 404);
            }

            var phoneNumberResponseDto = new PhoneNumberResponseDto
            {
                Number = phoneNumber,
                Country = new CountryDto
                {
                    CountryCode = country.CountryCode,
                    Name = country.Name,
                    CountryIso = country.CountryIso,
                    CountryDetails = country.CountryDetails.Select(cd => new CountryDetailDto
                    {
                        Operator = cd.Operator,
                        OperatorCode = cd.OperatorCode
                    }).ToList()
                }
            };

            _logger.LogInfo("Successfully retrieved country details for phone number: {PhoneNumber}", phoneNumber);

            return new APIResponse<PhoneNumberResponseDto>(phoneNumberResponseDto, 200, "Country details retrieved successfully.");
        }

        private string ExtractCountryCode(string phoneNumber)
        {
            _logger.LogInfo("Extracting country code from phone number: {PhoneNumber}", phoneNumber);

            
            var possibleCodes = new[] { "234", "233", "229", "225" };
            foreach (var code in possibleCodes)
            {
                if (phoneNumber.StartsWith(code))
                {
                    _logger.LogInfo("Matched country code: {CountryCode} for phone number: {PhoneNumber}", code, phoneNumber);
                    return code;
                }
            }

            _logger.LogError(null, "No matching country code found for phone number: {PhoneNumber}", phoneNumber);
            return null;
        }
    }
}
