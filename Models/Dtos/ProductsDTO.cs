using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ProductsDTO
    {
        public int ProductID { get; set; } // Not nullable
        public string ProductName { get; set; } = string.Empty; // Not nullable (nvarchar(40))

        public int? SupplierID { get; set; } // Nullable
        public int? CategoryID { get; set; } // Nullable
        public string? QuantityPerUnit { get; set; } // Nullable (nvarchar(20))

        public decimal? UnitPrice { get; set; } // Nullable (money)
        public short? UnitsInStock { get; set; } // Nullable (smallint)
        public short? UnitsOnOrder { get; set; } // Nullable (smallint)
        public short? ReorderLevel { get; set; } // Nullable (smallint)

        public bool Discontinued { get; set; } // Not nullable (bit)

        // Constructor to initialize all properties
        public ProductsDTO(int productID, string productName, int? supplierID, int? categoryID,
            string? quantityPerUnit, decimal? unitPrice, short? unitsInStock,
            short? unitsOnOrder, short? reorderLevel, bool discontinued)
        {
            ProductID = productID;
            ProductName = productName;
            SupplierID = supplierID;
            CategoryID = categoryID;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
    }
}
