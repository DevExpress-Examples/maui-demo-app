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
                    string resourceName = "DemoCenter.Maui.DemoModules.Grid.Images." + value.Replace(" ", "").ToLower() + ".jpg";
                    if (!String.IsNullOrEmpty(resourceName))
                        Photo = ImageSource.FromResource(resourceName);
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
    }
}
