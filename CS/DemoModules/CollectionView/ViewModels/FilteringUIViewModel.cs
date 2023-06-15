using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DemoCenter.Maui.DemoModules.CollectionView.Data;

namespace DemoCenter.Maui.ViewModels {
    public class FilteringUIViewModel : NotificationObject {
        readonly HouseSalesRepository repository;

        public FilteringUIViewModel() {
            AddToFavoritesCommand = new Command<House>(AddToFavorites);
            this.repository = new HouseSalesRepository();
            AddToFavorites(ItemsSource[1]);
            AddToFavorites(ItemsSource[3]);
            Update();
        }

        int selectedTabIndex;
        public int SelectedTabIndex {
            get => this.selectedTabIndex;
            set => SetProperty(ref this.selectedTabIndex, value, Update);
        }
        bool isHomeTabSelected;
        public bool IsHomeTabSelected {
            get => this.isHomeTabSelected;
            private set => SetProperty(ref this.isHomeTabSelected, value);
        }
        bool isFavoritesTabSelected;
        public bool IsFavoritesTabSelected {
            get => this.isFavoritesTabSelected;
            private set => SetProperty(ref this.isFavoritesTabSelected, value);
        }
        public IList<House> ItemsSource => this.repository.Houses;
        public ObservableCollection<House> Favorites { get; } = new ObservableCollection<House>();
        public ICommand AddToFavoritesCommand { get; }

        void AddToFavorites(House house) {
            if (Favorites.Contains(house)) {
                Favorites.Remove(house);
                house.IsFavorite = false;
            } else {
                Favorites.Add(house);
                house.IsFavorite = true;
            }
        }
        void Update() {
            IsHomeTabSelected = SelectedTabIndex == 0;
            IsFavoritesTabSelected = SelectedTabIndex == 1;
        }
    }
}
