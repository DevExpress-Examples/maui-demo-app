using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.TabView {
    public class Category: NotificationObject {
        bool isSelected;
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool IsSelected {
            get => this.isSelected;
            set => SetProperty(ref this.isSelected, value);
        }
    }
    public class Product: BindableObject {
        public static readonly BindableProperty CanAddToCartProperty =
            BindableProperty.Create(nameof(Product.CanAddToCart), typeof(bool), typeof(Product),
                defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty CanAddToWishListProperty =
            BindableProperty.Create(nameof(Product.CanAddToWishList), typeof(bool), typeof(Product),
                defaultBindingMode: BindingMode.TwoWay);

        public bool CanAddToCart {
            get => (bool)GetValue(CanAddToCartProperty);
            set => SetValue(CanAddToCartProperty, value);
        }
        public bool CanAddToWishList {
            get => (bool)GetValue(CanAddToWishListProperty);
            set => SetValue(CanAddToWishListProperty, value);
        }

        string imageName;
        readonly NestedTabViewModel parentModel;
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public ImageSource ImageSource { get; set; }

        public bool ToDelete => !CanAddToCart || !CanAddToWishList;
        public string ImageName {
            get => this.imageName;
            set {
                this.imageName = value;
                ImageSource = ImageSource.FromResource("DemoCenter.Maui.DemoModules.TabView.Resources.NestedTabViewImages." + value + ".png");
            }
        }
        public ICommand ChangeCart { get; }
        public ICommand ChangeWishList { get; }
        public Product(NestedTabViewModel parentModel) {
            this.parentModel = parentModel;
            CanAddToCart = true;
            CanAddToWishList = true;
            ChangeCart = new Command(() => parentModel.ChangeCart.Execute(this));
            ChangeWishList = new Command(() => parentModel.ChangeWishList.Execute(this));
        }
    }
}
