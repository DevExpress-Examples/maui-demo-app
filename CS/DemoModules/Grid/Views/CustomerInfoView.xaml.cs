using DemoCenter.Maui.DemoModules.Grid.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class CustomerOrdersView : ContentPage {        
        readonly Customer customer;

        public CustomerOrdersView() {
            InitializeComponent();

        }
    
        public CustomerOrdersView(Customer customer) : this() {
            this.customer = customer;
            this.BindingContext = customer;
        }
    }
}
