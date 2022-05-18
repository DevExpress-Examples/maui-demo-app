using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.ViewModels {
    public class ContactsViewModel : NotificationObject {
        readonly Random random;

        ObservableCollection<CallInfo> recent;
        public ObservableCollection<CallInfo> Recent {
            get => this.recent;
            private set {
                this.recent = value;
                OnPropertyChanged(nameof(Recent));
            }
        }

        public ContactsViewModel() {
            this.random = new Random();
            GridOrdersRepository repository = new GridOrdersRepository();
            IList<PhoneContact> customersList = repository.Customers.ToList().ConvertAll((customer) => new PhoneContact(customer));

            GenerateCallList(customersList);
        }

        void GenerateCallList(IList<PhoneContact> contacts) {
            int recordsCount = 21;
            Recent = new ObservableCollection<CallInfo>();
            for (int i = 0; i < recordsCount; i++) {
                int randomData = i / 3;
                int randomTime = this.random.Next(40, 620);
                Recent.Add(new CallInfo() {
                    Date = DateTime.UtcNow.AddDays(-randomData).AddMinutes(randomTime),
                    CallType = (CallType)((randomTime - randomData) % 3),
                    Contact = contacts[(randomData + randomTime) % contacts.Count]
                });
            }
        }
    }
}
