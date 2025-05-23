using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class EmployeesDTO
    {
        public int EmployeeID { get; set; } // Not nullable
        public string LastName { get; set; } = string.Empty; // Not nullable (nvarchar(20))
        public string FirstName { get; set; } = string.Empty; // Not nullable (nvarchar(10))

        public string? Title { get; set; } // Nullable (nvarchar(30))
        public string? TitleOfCourtesy { get; set; } // Nullable (nvarchar(25))
        public DateTime? BirthDate { get; set; } // Nullable (datetime)
        public DateTime? HireDate { get; set; } // Nullable (datetime)
        public string? Address { get; set; } // Nullable (nvarchar(60))
        public string? City { get; set; } // Nullable (nvarchar(15))
        public string? Region { get; set; } // Nullable (nvarchar(15))
        public string? PostalCode { get; set; } // Nullable (nvarchar(10))
        public string? Country { get; set; } // Nullable (nvarchar(15))
        public string? HomePhone { get; set; } // Nullable (nvarchar(24))
        public string? Extension { get; set; } // Nullable (nvarchar(4))

        public byte[]? Photo { get; set; } // Nullable (image → byte[])
        public string? Notes { get; set; } // Nullable (ntext)
        public int? ReportsTo { get; set; } // Nullable (int)
        public string? PhotoPath { get; set; } // Nullable (nvarchar(255))

        public EmployeesDTO(int employeeID, string lastName, string firstName, string? title,
                      string? titleOfCourtesy, DateTime? birthDate, DateTime? hireDate,
                      string? address, string? city, string? region, string? postalCode,
                      string? country, string? homePhone, string? extension, byte[]? photo,
                      string? notes, int? reportsTo, string? photoPath)
        {
            EmployeeID = employeeID;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
            PhotoPath = photoPath;
        }

    }
}
