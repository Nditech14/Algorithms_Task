using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PhoneNumberResponseDto
    {
        public string Number { get; set; }
        public CountryDto Country { get; set; }
    }
}
