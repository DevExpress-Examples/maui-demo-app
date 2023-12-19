using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class CustomerOrdersView : Demo.DemoPage {
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
