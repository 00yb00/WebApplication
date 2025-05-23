using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class OrdersDTO
    {
        public int OrderID { get; set; } // Not nullable

        public string? CustomerID { get; set; } // Nullable (nchar(5))
        public int? EmployeeID { get; set; } // Nullable

        public DateTime? OrderDate { get; set; } // Nullable
        public DateTime? RequiredDate { get; set; } // Nullable
        public DateTime? ShippedDate { get; set; } // Nullable

        public int? ShipVia { get; set; } // Nullable
        public decimal? Freight { get; set; } // Nullable

        public string? ShipName { get; set; } // Nullable (nvarchar(40))
        public string? ShipAddress { get; set; } // Nullable (nvarchar(60))
        public string? ShipCity { get; set; } // Nullable (nvarchar(15))
        public string? ShipRegion { get; set; } // Nullable (nvarchar(15))
        public string? ShipPostalCode { get; set; } // Nullable (nvarchar(10))
        public string? ShipCountry { get; set; } // Nullable (nvarchar(15))

        public OrdersDTO(int orderId, string? customerId, int? employeeId, DateTime? orderDate, DateTime? requiredDate,
                DateTime? shippedDate, int? shipVia, decimal? freight, string? shipName, string? shipAddress,
                string? shipCity, string? shipRegion, string? shipPostalCode, string? shipCountry)
        {
            OrderID = orderId;
            CustomerID = customerId;
            EmployeeID = employeeId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipVia = shipVia;
            Freight = freight;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipRegion = shipRegion;
            ShipPostalCode = shipPostalCode;
            ShipCountry = shipCountry;
        }
    }
}
