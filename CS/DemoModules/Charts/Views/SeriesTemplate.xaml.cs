using System;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Charts;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    class SeriesTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(container is SeriesTemplateAdapter adapter))
                return null;

            return adapter.SeriesDataMember == "Country" ? YearSeriesTemplate : CountrySeriesTemplate;
        }

        public DataTemplate YearSeriesTemplate { get; set; }
        public DataTemplate CountrySeriesTemplate { get; set; }
    }
}

namespace DemoCenter.Maui.Views {
    public partial class SeriesTemplate : ContentPage {
        readonly string[] members = { "Year", "Country" };

        public SeriesTemplate() {
            InitializeComponent();
        }

        async void OnItemClicked(System.Object sender, System.EventArgs e) {
            SeriesTemplateViewModel viewModel = (SeriesTemplateViewModel) BindingContext;
            
            string action = await DisplayActionSheet("Data Source Field", "Cancel", null, members);
            if (!String.IsNullOrEmpty(action) && action != "Cancel" && action != viewModel.SeriesDataMember) {
                viewModel.SeriesDataMember = action;
                viewModel.ArgumentDataMember = action == members[0] ? members[1] : members[0];
            }
        }
    }
}
