using System.Collections.ObjectModel;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public abstract class OrdersRepository {
        readonly ObservableCollection<Customer> customers;

        public ObservableCollection<Order> Orders { get; private set; }
        public ObservableCollection<Customer> Customers { get { return this.customers; } }

        public OrdersRepository() {
            Orders = new ObservableCollection<Order>();
            this.customers = new ObservableCollection<Customer>();
        }

        protected abstract Order GenerateOrder(int number);
        protected abstract int GetOrderCount();

        internal void LoadMoreOrders() {
            for (int i = 0; i < GetOrderCount() / 2; i++)
                Orders.Add(GenerateOrder(i));
        }
        internal void RefreshOrders() {
            ObservableCollection<Order> newOrders = new ObservableCollection<Order>();
            for (int i = 0; i < GetOrderCount(); i++)
                newOrders.Add(GenerateOrder(i));

            Orders = newOrders;
        }
    }
}
