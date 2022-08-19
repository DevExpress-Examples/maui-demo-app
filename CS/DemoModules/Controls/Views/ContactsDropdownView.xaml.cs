using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DevExpress.Maui.CollectionView;
using DemoCenter.Maui.DemoModules.TabView.Pages;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Services;

namespace DemoCenter.Maui.DemoModules.Popup.Views {
    public partial class ContactsDropdownView : ContentPage {

        ContactsDropdownViewModel viewModel = new ContactsDropdownViewModel();
        bool inNavigation = false;

        public ActiveItemCommand ItemCommand { get; }

        public ContactsDropdownView() {
            InitializeComponent();

            BindingContext = this.viewModel;
            ItemCommand = new ActiveItemCommand(this.viewModel);
        }

         protected override void OnAppearing() {
            base.OnAppearing();
            this.inNavigation = false;
        }

        public async void ItemSelected(object sender, CollectionViewGestureEventArgs args) {
            if (args.Item != null)
                await OpenDetailPage(GetContactInfo(args.Item));
        }

        private PhoneContact GetContactInfo(object item) {
            if (item is CallInfo callInfo)
                return callInfo?.Contact;
            return null;
        }

        Task OpenDetailPage(PhoneContact contact) {
            if (contact == null)
                return Task.CompletedTask;

            if (this.inNavigation)
                return Task.CompletedTask;

            this.inNavigation = true;
            return NavigationService.NavigateToPage(new ContactDetailPage(contact));
        }

        void OnRemoveClick(object sender, EventArgs e) {
            ItemCommand.RemoveFromList();
            this.viewModel.IsOpenPopup = false;
        }

        void OnCallClick(object sender, EventArgs e) {
            ItemCommand.CallNow();
            this.viewModel.IsOpenPopup = false;
        }

        void OnContactClick(object sender, EventArgs e) {
            this.viewModel.PlacementTarget = sender;
            this.viewModel.IsOpenPopup = !this.viewModel.IsOpenPopup;
        }
    }

    public class ActiveItemCommand: ICommand {
        public event EventHandler CanExecuteChanged;

        readonly ContactsDropdownViewModel vm;
        CallInfo activeItem;

        public ActiveItemCommand(ContactsDropdownViewModel vm) {
            this.vm = vm;
        }


        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter) {
            this.activeItem = parameter as CallInfo;
        }


        public void RemoveFromList() {
            this.vm.Recent.Remove(this.activeItem);
        }

        public void CallNow() {
            this.vm.Recent.Remove(this.activeItem);
            this.activeItem.Date = DateTime.Now;
            this.activeItem.CallType = CallType.Outgoing;
            this.vm.Recent.Add(this.activeItem);
        }
    }
}
