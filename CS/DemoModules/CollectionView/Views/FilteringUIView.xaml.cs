using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Services;
using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class FilteringUIView : Demo.AdaptivePage {
        EnumToDescriptionConverter EnumToDescriptionConverter { get; } = new EnumToDescriptionConverter();
        FilteringUIViewModel ViewModel { get; }

        public FilteringUIView() {
            InitializeComponent();
            ViewModel = new FilteringUIViewModel();
            BindingContext = ViewModel;
            UpdateColumnsCount();
            OrientationChanged += OnOrientationChanged;
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            UpdateColumnsCount();
        }
        void UpdateColumnsCount() {
            double currentScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            ViewModel.ColumnsCount = ON.Idiom<int>(ON.Orientation<int>(1, 2), ON.Orientation<int>(2, Height < 600 ? 2 : 4));
        }
        void OnCustomDisplayText(object sender, FilterElementCustomDisplayTextEventArgs e) {
            e.DisplayText = EnumToDescriptionConverter.Convert(e.Value).ToString();
        }
        void OnFilteringUIFormShowing(object sender, FilteringUIFormShowingEventArgs e) {
            if (e.Form is not ContentPage page)
                return;
            NavigationService.SetDemoPageTitleView(page, "Filters");
        }
    }
}
