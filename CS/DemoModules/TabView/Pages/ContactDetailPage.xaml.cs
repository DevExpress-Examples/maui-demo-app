using DemoCenter.Maui.DemoModules.TabView.ViewModels;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.TabView.Pages {
    public partial class ContactDetailPage : ContentPage {
        readonly ContactDetailPageViewModel viewModel;
        public ContactDetailPage(PhoneContact contactInfo) {
            this.viewModel = new ContactDetailPageViewModel(contactInfo);
            InitializeComponent();
            BindingContext = this.viewModel;
        }
    }
}
