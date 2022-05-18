using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Data {
    [XmlRoot(ElementName = "CompaniesData")]
    public class CompaniesData : List<CompanyData> { }

    public class CompanyData: NotificationObject {
        bool isSelected;
        public ImageSource ImageSource { get {
                return ImageSource.FromResource(CompanyBanner);
            }
        }
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBanner { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public bool IsSelected {
            get => this.isSelected;
            set => SetProperty(ref this.isSelected, value);
        }

        public string ViewCity { get { return String.Format("{0} ({1})", City, State); } }
        public string ViewAddress { get { return String.Format("{0} {1}", Zipcode, Address); } }
    }
}
