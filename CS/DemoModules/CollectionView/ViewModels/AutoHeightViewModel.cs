using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.ViewModels {
    public class AutoHeightViewModel : NotificationObject {
        readonly OrdersRepository repository;

        public IList<Customer> ItemSource => this.repository.Customers;

        public AutoHeightViewModel(OrdersRepository repository) {
            this.repository = repository;
        }
    }
}
