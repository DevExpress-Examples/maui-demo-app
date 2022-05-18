using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class Employee {
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
        public string ImageData { get; set; }
        public string FullName{
            get {
                return FirstName + " " + LastName;
            }
        }
        public ImageSource Image {
            get {
                byte[] bytes = Convert.FromBase64String(ImageData);
                MemoryStream ms = new MemoryStream(bytes);
                return ImageSource.FromStream(() => ms);
            }
        }
    }
}
