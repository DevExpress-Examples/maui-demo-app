using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Utils;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class DemoTabPagesViewModel : NavigationViewModelBase {
        readonly Random rand;

        ObservableCollection<PhoneContact> contacts;
        public ObservableCollection<PhoneContact> Contacts {
            get => this.contacts;

            private set {
                this.contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        ObservableCollection<CallInfo> recent;
        public ObservableCollection<CallInfo> Recent {
            get => this.recent;
            private set {
                this.recent = value;
                OnPropertyChanged(nameof(Recent));
            }
        }

        public ObservableCollection<PhoneContact> Favorites => new ObservableCollection<PhoneContact>(Contacts.Where(c => c.Favorite));

        public DemoTabPagesViewModel() {
            this.rand = new Random();
            InitContacts();
        }

        private void InitContacts() {
            GridOrdersRepository repository = new GridOrdersRepository();
            IList<PhoneContact> customersList = repository.Customers.ToList().ConvertAll((customer) => new PhoneContact(customer));

            GenerateCallList(customersList);
            GenerateFavoritesList(customersList);
            Contacts = new ObservableCollection<PhoneContact>(customersList);
        }

        
        void GenerateCallList(IList<PhoneContact> contacts) {
            int recordsCount = this.rand.Next(2, 10);
            Recent = new ObservableCollection<CallInfo>();
            for (int i = 0; i < recordsCount; i++) {
                int randomData = this.rand.Next(2, 10);
                int randomTime = this.rand.Next(40, 620);
                Recent.Add(new CallInfo() {
                    Date = DateTime.UtcNow.AddDays(-randomData).AddMinutes(randomTime),
                    CallType = (CallType)((randomTime - randomData) % 3),
                    Contact = contacts[(randomData + randomTime) % contacts.Count]
                });
            }
        }

        void GenerateFavoritesList(IList<PhoneContact> contacts) {
            int recordsCount = this.rand.Next(5, 15);
            for (int i = 0; i < recordsCount; i++) {
                int randomContactNum = this.rand.Next(0, contacts.Count - 1);
                contacts[randomContactNum].Favorite = true;
            }
        }
    }
    public class PhoneContact : Customer {
        Color contactColor = DXColor.Default;

        public PhoneContact(string name) : base(name) { }
        public PhoneContact(Customer customer) : base(customer.Name) {
            Id = customer.Id;
            Notes = customer.Notes;
            Phone = customer.Phone;
            Photo = customer.Photo;
            Email = customer.Email;
            BirthDate = customer.BirthDate;
        }
        public bool HasPhoto { get; } = new Random().Next(0, 18) % 3 == 0;
        public bool Favorite { get; set; }
        public Color CategoryColor => GetContactColor();
        public string Initials => Name.Substring(0, 1) + Name.Split(null)[1].Substring(0, 1);

        internal Color GetContactColor() {
            if (this.contactColor == DXColor.Default) {
                this.contactColor = ContactColors.GetRandomColor();
            }
            return this.contactColor;
        }
    }
    public class CallInfo {
        public DateTime Date { get; set; }
        public CallType CallType { get; set; }
        public string Name => Contact?.Name;
        public string Phone => Contact?.Phone;
        public Color CategoryColor => Contact != null ? Contact.CategoryColor : DXColor.Default;
        public string Initials => Contact?.Initials;
        public PhoneContact Contact { get; set; }
    }
    public enum CallType {
        Incoming,
        Outgoing,
        Missed
    }
}
