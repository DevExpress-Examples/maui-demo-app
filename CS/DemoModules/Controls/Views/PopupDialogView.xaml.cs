using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.DemoModules.CollectionView.Data;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Popup.Views {
    public partial class PopupDialogView : ContentPage {

        PopupDialogViewModel viewModel;
        bool isAnimated;

        public PopupDialogView() {
            InitializeComponent();

            this.viewModel = new PopupDialogViewModel(new EmployeeTasksRepository());

            BindingContext = this.viewModel;
        }

        void OnTap(object sender, DevExpress.Maui.CollectionView.CollectionViewGestureEventArgs e) {
            this.viewModel.PreparePopupAndOpen(e.Item as EmployeeTask, e.ItemHandle);
        }

        void DismissPopup(object sender, EventArgs e) {
            this.viewModel.IsOpenPopup = false;
        }

        void PinClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Urgent;
            OnStatusChanged();
        }

        void DoneClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Completed;
            OnStatusChanged();
        }

        void ToDoClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Uncompleted;
            OnStatusChanged();
        }

        void DeleteClick(object sender, EventArgs e) {
            this.viewModel.IsOpenPopup = false;
            this.collectionView.DeleteItem(this.viewModel.ItemHandle);
        }

        void OnStatusChanged() {
            if (this.isAnimated) return;

            this.viewModel.IsOpenPopup = false;

            IList<EmployeeTask> source = this.viewModel.ItemSource;

            int newItemHandle = 0;

            switch (this.viewModel.ActiveItem.Status) {
                case TaskStatus.Urgent:
                    newItemHandle = 0;
                    break;
                case TaskStatus.Completed:
                    newItemHandle = source.Count() - 1;
                    break;
                case TaskStatus.Uncompleted:
                    newItemHandle = source.Where(t => t.Status == TaskStatus.Urgent).Count();
                    break;
            }

            if (this.viewModel.ItemHandle == newItemHandle)
                return;

            this.isAnimated = true;
            Device.BeginInvokeOnMainThread(() =>
                this.collectionView.MoveItem(this.viewModel.ItemHandle, newItemHandle, () => this.isAnimated = false)
            );
        }
    }
}
