using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.ViewModels {
    public class ContactsDropdownViewModel: NotificationObject {
        readonly Random random;

        ObservableCollection<CallInfo> recent;
        public ObservableCollection<CallInfo> Recent {
            get => this.recent;
            private set => SetProperty(ref this.recent, value);
        }

        bool isOpenPopup;
        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set => SetProperty(ref this.isOpenPopup, value);
        }

        object placementTarget;
        public object PlacementTarget {
            get => this.placementTarget;
            set => SetProperty(ref this.placementTarget, value);
        }

        public ContactsDropdownViewModel() {
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
