using System;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class PhoneListView : ContentPage {
        public PhoneListView() {
            InitializeComponent();
            BindingContext = new PhoneListViewModel();
        }
      
        async void OnItemClicked(object sender, EventArgs e) {
            string action = await DisplayActionSheet("Group by", "Cancel", null, GroupParameterName.Alphabeticaly.ToString(), GroupParameterName.Category.ToString());
            if (action != null && action != "Cancel") {
                PhoneListViewModel model = BindingContext as PhoneListViewModel;
                if (model != null && model.GroupParameter.ToString() != action) {
                    GroupParameterName parameter = action == GroupParameterName.Alphabeticaly.ToString()? GroupParameterName.Alphabeticaly: GroupParameterName.Category;
                    model.SelectedItem = model.PhoneListData[0];
                    model.SetGroupByParameter(parameter);
                    if (model.GroupParameter == GroupParameterName.Alphabeticaly) {
                        this.dxTabView.HeaderPanelPosition = Position.Right;
                        this.dxTabView.HeaderPanelContentAlignment = ContentAlignment.Start;
                    } else {
                        this.dxTabView.HeaderPanelPosition = Position.Bottom;
                        this.dxTabView.HeaderPanelContentAlignment = ContentAlignment.Center;
                    }
                    this.dxTabView.ItemsSource = model.PhoneListData;
                    this.dxTabView.SelectedItem = model.PhoneListData[0];
                }
            }
        }
    }
}
