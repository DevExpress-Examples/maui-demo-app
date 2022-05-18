using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.TabView {
    public class NestedTabViewModel : NavigationViewModelBase {
        Category selectedCategory;
        public List<Product> ProductsData { get => AllProducts.SelectMany(p => p.Products).ToList(); }

        public List<Category> AllProducts { get; private set; } = new List<Category>() {};
        public ObservableCollection<Product> Cart { get; private set; }
        public ObservableCollection<Product> WishList { get; private set; }

        public Category SelectedCategory {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value, onChanged: (oldValue, newValue) => {
                ResetSelectedCategory(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        public ICommand ChangeCart { get; }
        public ICommand ChangeWishList { get; }

        public NestedTabViewModel() {
            ChangeCart = new DelegateCommand<Product> ((p) => ExecuteChangeCart(p));
            ChangeWishList = new DelegateCommand<Product>((p) => ExecuteChangeWishList(p));
            GenerateTestData();
        }
        private void GenerateTestData() {
            Category tv = new Category() {
                Name = "Televisions",
                Products = new List<Product>() {
                    new Product(this) { Name = "SuperLCD 42", Category = "Television", Price = "$1200", ImageName="7", Description="The 42” Super LCD TV is changing the way people watch TV. It’s amazing build quality and high precision design means you get the best possible picture for the best possible price."},
                    new Product(this) { Name = "SuperLED 42", Category = "Television", Price = "$1450", ImageName="5", Description="The 42” Super LED TV is changing the way people watch TV. It’s amazing build quality and high precision design means you get the best possible picture for the best possible price."},
                    new Product(this) { Name = "SuperLED 50", Category = "Television", Price = "$1600", ImageName="4", Description="The 50” Super LED TV is changing the way people watch TV. It’s amazing build quality and high precision design means you get the best possible picture for the best possible price."},
                    new Product(this) { Name = "SuperLCD 55", Category = "Television", Price = "$1350", ImageName="6", Description="The 55” Super Super LCD TV is changing the way people watch TV. It’s amazing build quality and high precision design means you get the best possible picture for the best possible price."},
                    new Product(this) { Name = "SuperLCD 70", Category = "Television", Price = "$4000", ImageName="9", Description="The 70” Super SuperLCD TV is changing the way people watch TV. It’s amazing build quality and high precision design means you get the best possible picture for the best possible price."}
                }
            };
            Category monitors = new Category() {
                Name = "Monitors",
                Products = new List<Product>() {
                    new Product(this) { Name = "DesktopLCD 19", Category = "Monitor", Price = "$160", ImageName="10", Description="The 19” Brilliance LCD Computer Monitor is changing the way people display computer signals. It’s amazing build quality and high precision design means you get the best possible computer picture."},
                    new Product(this) { Name = "DesktopLCD 21", Category = "Monitor", Price = "$170", ImageName="12", Description="The 21” Brilliance LCD Computer Monitor is changing the way people display computer signals. It’s amazing build quality and high precision design means you get the best possible computer picture."},
                    new Product(this) { Name = "DesktopLED 21", Category = "Monitor", Price = "$180", ImageName="13", Description="The 21” Brilliance LED Computer Monitor is changing the way people display computer signals. It’s amazing build quality and high precision design means you get the best possible computer picture."}
                }
            };
            Category projectors = new Category() {
                Name = "Projectors",
                Products = new List<Product>() {
                    new Product(this) { Name = "Projector Plus", Category = "Projector", Price = "$550", ImageName="14", Description="The HD Projector gives the home theater enthusiast HD output at a super low price. It has a compact design and is both easy to install and setup."},
                    new Product(this) { Name = "Projector Plus HD", Category = "Projector", Price = "$750", ImageName="15", Description="The Super HD Projector gives the home theater enthusiast HD output at a low price. It has a compact design and is both easy to install and setup."},
                }
            };
            Category videoPlayers = new Category() {
                Name = "Video Players",
                Products = new List<Product>() {
                    new Product(this) { Name = "HD Video Player", Category = "Video Player", Price = "$220", ImageName="1", Description="Get ready to be blown away by the world’s best HD Video Player. Powered by our newest chipset, the HD Video Player upscales and upconverts like never before."},
                    new Product(this) { Name = "SuperHD Video Player", Category = "Video Player", Price = "$270", ImageName="2", Description="Get ready to be blown away by the world’s best HD Video Player. Powered by our newest chipset, the SuperHD Video Player upscales and upconverts like never before."},
                }
            };

            AllProducts = new List<Category>() { tv, monitors, projectors, videoPlayers };
            AllProducts[0].IsSelected = true;

            Cart = new ObservableCollection<Product>() {
                monitors.Products[1],
                tv.Products[1],
                videoPlayers.Products[1],
                projectors.Products[1]
            };
            monitors.Products[1].CanAddToCart = false;
            tv.Products[1].CanAddToCart = false;
            videoPlayers.Products[1].CanAddToCart = false;
            projectors.Products[1].CanAddToCart = false;

            WishList = new ObservableCollection<Product>() {
                monitors.Products[2],
                tv.Products[2],
                videoPlayers.Products[0],
                projectors.Products[0],
                tv.Products[3]
            };
            monitors.Products[2].CanAddToWishList = false;
            tv.Products[2].CanAddToWishList = false;
            videoPlayers.Products[0].CanAddToWishList = false;
            projectors.Products[0].CanAddToWishList = false;
            tv.Products[3].CanAddToWishList = false;
        }
        void ResetSelectedCategory(Category oldValue) {
            if(oldValue != null) {
                oldValue.IsSelected = false;
            } else {
                foreach(Category curentItem in AllProducts) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
        void ExecuteChangeCart(Product item) {
            if (item.CanAddToCart) {
                if (Cart.Contains(item))
                    return;
                item.CanAddToCart = false;
                Cart.Add(item);
            } else {
                if(!Cart.Contains(item))
                    return;
                item.CanAddToCart = true;
                Cart.Remove(item);

            }
        }
        void ExecuteChangeWishList(Product item) {
            if (item.CanAddToWishList) {
                if (WishList.Contains(item))
                    return;
                item.CanAddToWishList = false;
                WishList.Add(item);
            } else {
                if (!WishList.Contains(item))
                    return;
                item.CanAddToWishList = true;
                WishList.Remove(item);
            }
        }
    }
}
