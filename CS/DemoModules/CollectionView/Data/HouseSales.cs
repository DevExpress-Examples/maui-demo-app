using System.ComponentModel;
using Microsoft.Maui.Controls;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data {
    public enum PropertyType {
        [Description("Single Family Home")]
        SingleFamilyHome,
        [Description("Condo/Townhouse")]
        Townhome,
        [Description("Multi-Family Home")]
        MultiFamilyHome
    };
    public enum PropertyStatus {
        [Description("Rent")]
        Rent,
        [Description("Buy")]
        Buy
    };

    public class House : NotificationObject {
        string imageName;

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public double HouseSize { get; set; }
        public double LotSize { get; set; }
        public decimal Price { get; set; }
        public int YearBuilt { get; set; }
        public bool IsGarageExist => !(Id == 2 || Id == 4 || (Id >= 8 && Id <= 10) || Id == 15 || Id == 17 || Id == 18 || Id == 20 || Id == 22 || Id == 23);
        public PropertyType Type { get; set; }
        public PropertyStatus Status { get; set; }
        public string Description { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ImageName {
            get => this.imageName;
            set {
                this.imageName = value;
                ImageSource = ImageSource.FromFile("house" + value + ".jpg");
            }
        }
        bool isFavorite;
        public bool IsFavorite {
            get => this.isFavorite;
            set => SetProperty(ref this.isFavorite, value);
        }
    }
}
