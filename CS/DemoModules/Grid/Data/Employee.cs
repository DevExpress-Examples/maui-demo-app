using System;
using System.Text.Json.Serialization;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class Employee {
        public Employee() { }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        public string GroupName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string ImageData { set => Image = ImageSource.FromFile(value); }
        [JsonIgnore] public ImageSource Image { get; set; }
        [JsonIgnore] public string Relationship => $"Id: {Id}, ParentId: {ParentId}";
    }
}
