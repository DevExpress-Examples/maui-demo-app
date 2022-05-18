using System;
using System.Collections.ObjectModel;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public enum OrderPriority {
        High,
        Medium,
        Low
    }
    public enum Severity {
        Severe,
        Moderate,
        Minor
    }
    public class OrderSeverity {
        public Severity Severity { get; set; }
        public string DisplayText { get; set; }
    }
    public class Order : NotificationObject {
        readonly ObservableCollection<OrderEntry> entries;
        readonly ReadOnlyObservableCollection<OrderEntry> readOnlyEntries;
        DateTime date;
        int id;
        Customer customer;
        bool shipped;
        decimal total = Decimal.MinValue;
        string note;
        OrderPriority priority;

        public int Id {
            get { return id; }
            set {
                if (id != value) {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public Customer Customer {
            get { return customer; }
            set {
                if (customer != value) {
                    customer = value;
                    OnPropertyChanged("Customer");
                }
            }
        }
        public DateTime Date {
            get { return date; }
            set {
                if (date != value) {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public bool Shipped {
            get { return shipped; }
            set {
                if (shipped != value) {
                    shipped = value;
                    OnPropertyChanged("Shipped");
                }
            }
        }
        public double Discount { get; set; }
        public decimal Total {
            get {
                if (total == decimal.MinValue)
                    total = CalculateTotal();
                return total;
            }
        }
        public string Note {
            get { return note; }
            set {
                if (note != value) {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        public OrderPriority Priority {
            get { return priority; }
            set {
                if (priority != value) {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }
        public ReadOnlyObservableCollection<OrderEntry> Entries {
            get { return readOnlyEntries; }
        }

        public Order(Customer customer, int id, DateTime date, bool isDone) {
            this.entries = new ObservableCollection<OrderEntry>();
            this.readOnlyEntries = new ReadOnlyObservableCollection<OrderEntry>(this.entries);
            this.customer = customer;
            this.id = id;
            this.date = date;
            this.shipped = isDone;
            this.note = "test note";
        }

        public Order() {
            this.entries = new ObservableCollection<OrderEntry>();
            this.readOnlyEntries = new ReadOnlyObservableCollection<OrderEntry>(this.entries);
            this.customer = new Customer("");
            this.id = 0;
            this.date = new DateTime();
            this.shipped = false;
            this.note = "";
        }

        public void AddEntry(OrderEntry entry) {
            total = Decimal.MinValue;
            entries.Add(entry);
        }
        public void RemoveEntry(OrderEntry entry) {
            total = Decimal.MinValue;
            entries.Remove(entry);
        }

        decimal CalculateTotal() {
            decimal result = 0;
            int count = entries.Count;
            for (int i = 0; i < count; i++)
                result += (decimal)entries[i].Total;
            return result;
        }
    }
}
