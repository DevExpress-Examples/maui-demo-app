using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.Services;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class SwipeButtonsView : BaseGridContentPage { 
        public SwipeButtonsView() {
            Resources.Add("IsTablet", DeviceInfo.Idiom == DeviceIdiom.Tablet);
            InitializeComponent();
        }

        protected override object LoadData() {
            return new OutlookDataRepository();
        }
        
        void OnShowCustomerInfo(object sender, SwipeItemTapEventArgs e) {
            Customer customer = (e.Item as OutlookData).From;
            CustomerOrdersView customerOrdersView = new CustomerOrdersView(customer) {
                Title = customer.Name
            };
            NavigationService.NavigateToPage(customerOrdersView);
        }
        
        void OnDelete(object sender, SwipeItemTapEventArgs e) {
            this.grid.DeleteRow(e.RowHandle);
        }

        void OnReply(object sender, SwipeItemTapEventArgs e) {
            try {
                Launcher.OpenAsync(new Uri("mailto:" + (e.Item as OutlookData).From.Email));
            } catch {
            }
        }
    }
}
