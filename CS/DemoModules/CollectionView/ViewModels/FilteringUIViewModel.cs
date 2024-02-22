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
            ChangeItemsLayoutCommand = new Command(ChangeItemsLayout);
            this.repository = new HouseSalesRepository();
            AddToFavorites(ItemsSource[1]);
            AddToFavorites(ItemsSource[3]);
            Update();
        }

        bool isSingleColumn = true;
        public bool IsSingleColumn {
            get => this.isSingleColumn;
            private set => SetProperty(ref this.isSingleColumn, value);
        }
        int columnsCount = 1;
        public int ColumnsCount {
            get => this.columnsCount;
            set => SetProperty(ref this.columnsCount, value, () => IsSingleColumn = ColumnsCount == 1);
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
        public ICommand ChangeItemsLayoutCommand { get; }

        void AddToFavorites(House house) {
            if (Favorites.Remove(house)) {
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
        void ChangeItemsLayout() {
            IsSingleColumn = !IsSingleColumn;
            ColumnsCount = IsSingleColumn ? 1 : 2;
        }
    }
}
