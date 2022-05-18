using System;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class Invoice {
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipperName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitPriceInt { get { return (int)UnitPrice; } }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double Freight { get; set; }
    }
}
