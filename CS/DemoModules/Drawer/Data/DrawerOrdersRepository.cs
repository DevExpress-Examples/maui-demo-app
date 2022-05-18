using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.TabView;

namespace DemoCenter.Maui.DemoModules.Drawer.Data {
    public class DrawerOrdersRepository : GridOrdersRepository {
        readonly NestedTabViewModel productsModel = new NestedTabViewModel();

        public IList<string> Companies { get; } = new List<string>() {
            "Electronics Depot",
            "K&S Music",
            "Walters",
            "E-Mart",
            "Video Emporium"
        };

        public ObservableCollection<Invoice> Invoices => GetInvoices(this.Orders);
        public ObservableCollection<CompanyCustomer> CompanyCustomers => GetCustomers(this.Customers);

        ObservableCollection<CompanyCustomer> GetCustomers(ObservableCollection<Customer> customers) {
            IList<CompanyCustomer> result = customers.ToList().ConvertAll((customer) => {
                return new CompanyCustomer(customer) {
                    CompanyName = Companies[random.Next(0, Companies.Count - 1)]
                };
            });
            return new ObservableCollection<CompanyCustomer>(result);
        }

        ObservableCollection<Invoice> GetInvoices(IList<Order> orders) {
            ObservableCollection<Invoice> result = new ObservableCollection<Invoice>();
            foreach (Order order in orders) {
                foreach (OrderEntry orderEntry in order.Entries) {
                    result.Add(new Invoice() {
                        OrderID = random.Next(1024, 1039),
                        CustomerID = order.Customer.Id.ToString(),
                        OrderDate = order.Date,
                        ShippedDate = order.Date.AddHours(random.Next(24, 80)),
                        CustomerName = order.Customer.Name,
                        Discount = order.Discount,
                        Quantity = random.Next(1, 5),
                        ProductName = orderEntry.Commodity.Name,
                        UnitPrice = Convert.ToDouble(productsModel.ProductsData.First(p => p.Name == orderEntry.Commodity.Name).Price.Substring(1))
                    });
                }
            }
            return result;
        }

        protected override void GenerateCommodities() {
            foreach (Product product in productsModel.ProductsData) {
                this.availableCommodities.Add(new Commodity(product.Name));
            }
        }
    }
}
