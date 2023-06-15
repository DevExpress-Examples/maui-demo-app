using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Services;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class FilteringUIView : Demo.DemoPage {
        EnumToDescriptionConverter EnumToDescriptionConverter { get; } = new EnumToDescriptionConverter();

        public FilteringUIView() {
            InitializeComponent();
            BindingContext = new FilteringUIViewModel();
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
