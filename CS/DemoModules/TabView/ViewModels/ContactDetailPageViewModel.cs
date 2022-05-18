using System;
using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.DemoModules.TabView.ViewModels {
    public class ContactDetailPageViewModel : BaseViewModel {
        readonly Random rand;
        readonly PhoneContact contact;

        IList<CallInfo> calls;
        public IList<CallInfo> CallsHistory {
            get => this.calls;
            set {
                this.calls = value;
                OnPropertyChanged(nameof(CallsHistory));
            }
        }

        public string Name {
            get => this.contact.Name;
        }

        public ImageSource Photo {
            get => this.contact.Photo;
        }
        
        public bool HasPhoto {
            get => this.contact.HasPhoto;
        }

        public string Initials {
            get => this.contact.Initials;
        }
        
        public Color CategoryColor {
            get => this.contact.CategoryColor;
        }

        public string Email {
            get => this.contact.Email;
        }

        public string Phone {
            get => this.contact.Phone;
        }

        public ContactDetailPageViewModel(PhoneContact contact) {
            this.rand = new Random();
            this.contact = contact;
            GenerateCallsHistory();
        }

        void GenerateCallsHistory() {
            int callsCount = this.rand.Next(2, 7);
            List<CallInfo> callsHistory = new List<CallInfo>();
            for (int i = 0; i < callsCount; i++) {
                int randParameter = this.rand.Next(1, 35);
                callsHistory.Add(new CallInfo() {
                    CallType = (CallType)((i + randParameter) % 3),
                    Date = DateTime.UtcNow.AddHours( -1 * (i + randParameter)).AddMinutes(randParameter)
                });
            }
            CallsHistory = callsHistory;
        }
    }
}
