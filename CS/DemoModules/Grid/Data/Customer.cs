using System;
using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class Customer : NotificationObject, IComparable<Customer>, IEquatable<Customer> {
        string name;

        public string Name {
            get => this.name;
            set {
                this.name = value;
                if (Photo == null) {
                    string fileName = value.Replace(" ", "").ToLower() + ".jpg";
                    if (!String.IsNullOrEmpty(fileName))
                        Photo = ImageSource.FromFile(fileName);
                }
            }
        }

        public Customer() {
        }

        public Customer(string name) {
            Name = name;
        }

        public int Id { get; set; }
        public ImageSource Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }

        public int CompareTo(Customer other) {
            return Comparer<string>.Default.Compare(Name, other.Name);
        }

        bool IEquatable<Customer>.Equals(Customer other) {
            return Name == other.Name;
        }

        public Customer Clone() {
            Customer result = new Customer(Name) {
                Id = Id,
                BirthDate = BirthDate,
                HireDate = HireDate,
                Position = Position,
                Address = Address,
                Phone = Phone,
                Notes = Notes,
                Email = Email
            };

            return result;
        }

        public override bool Equals(object obj) {
            return ((IEquatable<Customer>)this).Equals(obj as Customer);
        }
    }
}
