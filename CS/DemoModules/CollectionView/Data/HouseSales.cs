using System;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data {
    public class HouseSales {
        string imageName;

        public int Id { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ImageName {
            get => this.imageName;
            set {
                this.imageName = value;
                ImageSource = ImageSource.FromResource("DemoCenter.Maui.DemoModules.CollectionView.Images.house" + value + ".jpg");
            }
        }

        public HouseSales() {
        }
    }
}
