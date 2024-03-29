using DemoCenter.Maui.DemoModules.TabView.ViewModels;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.TabView.Pages {
    public partial class ContactDetailPage : Demo.DemoPage {
        readonly ContactDetailPageViewModel viewModel;
        public ContactDetailPage(PhoneContact contactInfo) {
            this.viewModel = new ContactDetailPageViewModel(contactInfo);
            InitializeComponent();
            BindingContext = this.viewModel;
        }
    }
}
