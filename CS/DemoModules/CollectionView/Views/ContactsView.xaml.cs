using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.TabView.Pages;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.CollectionView;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class ContactsView : Demo.DemoPage {
        static PhoneContact GetContactInfo(object item) {
            if (item is CallInfo callInfo)
                return callInfo?.Contact;
            return null;
        }
        bool inNavigation;

        public ContactsView() {
            InitializeComponent();
            BindingContext = new ContactsViewModel();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            this.inNavigation = false;
        }

        public async void ItemSelected(object sender, CollectionViewGestureEventArgs args) {
            if (args.Item != null)
                await OpenDetailPage(GetContactInfo(args.Item));
        }

        Task OpenDetailPage(PhoneContact contact) {
            if (contact == null)
                return Task.CompletedTask;

            if (this.inNavigation)
                return Task.CompletedTask;

            this.inNavigation = true;
            return NavigationService.NavigateToPage(new ContactDetailPage(contact));
        }
    }
}
