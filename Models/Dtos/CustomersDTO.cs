using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class CustomersDTO
    {
        public string CustomerID { get; set; } = string.Empty; // Not nullable (nchar(5))
        public string CompanyName { get; set; } = string.Empty; // Not nullable (nvarchar(40))

        public string? ContactName { get; set; } // Nullable (nvarchar(30))
        public string? ContactTitle { get; set; } // Nullable (nvarchar(30))
        public string? Address { get; set; } // Nullable (nvarchar(60))
        public string? City { get; set; } // Nullable (nvarchar(15))
        public string? Region { get; set; } // Nullable (nvarchar(15))
        public string? PostalCode { get; set; } // Nullable (nvarchar(10))
        public string? Country { get; set; } // Nullable (nvarchar(15))
        public string? Phone { get; set; } // Nullable (nvarchar(24))
        public string? Fax { get; set; } // Nullable (nvarchar(24))

        public CustomersDTO(string customerID, string companyName, string? contactName, string? contactTitle,
                      string? address, string? city, string? region, string? postalCode,
                      string? country, string? phone, string? fax)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
        }
    }
}
