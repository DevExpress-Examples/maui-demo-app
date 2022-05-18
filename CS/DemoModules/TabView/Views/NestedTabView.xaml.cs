using System;
using System.ComponentModel;
using DemoCenter.Maui.DemoModules.TabView;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class NestedTabView : ContentPage {
        public NestedTabView() {
            BindingContext = new NestedTabViewModel();
            ((NestedTabViewModel)BindingContext).PropertyChanged += OnModelPropertyChanged;
            InitializeComponent();
        }

        void UpdateSizeChanged(object sender, EventArgs e) {
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                ListView list = (ListView)sender;
                if (list != null)
                    UpdateItemSize(list.Width);
            }
        }

        void UpdateItemSize(double width) {
            int count = this.nestedTabView.Items.Count;
            if (count != 0) {
                double itemWidth = (width - (this.nestedTabView.HeaderPanelItemSpacing * (count-1))) / count;
                for (int i = 0; i < count; i++)
                    this.nestedTabView.Items[i].HeaderWidth = itemWidth;
            }
        }
        void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
