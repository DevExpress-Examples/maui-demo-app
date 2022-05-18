using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.DemoModules.Drawer.Data {
    public class CompanyCustomer : Customer {
        public CompanyCustomer(Customer customer) : base(customer.Name) {
            Id = customer.Id;
            BirthDate = customer.BirthDate;
            HireDate = customer.HireDate;
            Position = customer.Position;
            Address = customer.Address;
            Phone = customer.Phone;
            Notes = customer.Notes;
            Email = customer.Email;
        }

        string companyName;
        public string CompanyName {
            get => companyName;
            set {
                if (companyName != value) {
                    companyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }
    }
}
