using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class OrderEntry : NotificationObject {
        Commodity commodity;
        double amount;
        double price;
        double total;

        public Commodity Commodity {
            get { return commodity; }
            set {
                commodity = value;
                OnPropertyChanged("Commodity");
            }
        }
        public double Amount {
            get { return amount; }
            set {
                amount = value;
                OnPropertyChanged("Amount");
                UpdateTotal(raiseChanged: true);
            }
        }
        public double Price {
            get { return amount; }
            set {
                amount = value;
                OnPropertyChanged("Price");
                UpdateTotal(raiseChanged: true);
            }
        }
        public double Total {
            get { return total; }
        }

        public OrderEntry(Commodity commodity, double amount, double price) {
            this.commodity = commodity;
            this.amount = amount;
            this.price = price;
            UpdateTotal(raiseChanged: false);
        }

        void UpdateTotal(bool raiseChanged) {
            total = price * amount;
            if (raiseChanged)
                OnPropertyChanged("Total");
        }
    }
}
