using System;
using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.CollectionView.Data;

namespace DemoCenter.Maui.ViewModels {

    public class PopupDialogViewModel: NotificationObject {
        readonly EmployeeTasksRepository repository;

        public int ItemHandle { get; private set; }
        public EmployeeTask ActiveItem { get; private set; }

        string popupTitle;
        public string PopupTitle {
            get => this.popupTitle;
            set => SetProperty(ref this.popupTitle, value);
        }

        bool buttonPinVisible = false;
        public bool ButtonPinVisible {
            get => this.buttonPinVisible;
            set => SetProperty(ref this.buttonPinVisible, value);
        }

        bool buttonDoneVisible = false;
        public bool ButtonDoneVisible {
            get => this.buttonDoneVisible;
            set => SetProperty(ref this.buttonDoneVisible, value);
        }

        bool buttonToDoVisible = false;
        public bool ButtonToDoVisible {
            get => this.buttonToDoVisible;
            set => SetProperty(ref this.buttonToDoVisible, value);
        }

        bool isOpenPopup;
        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set => SetProperty(ref this.isOpenPopup, value);
        }

        public IList<EmployeeTask> ItemSource => this.repository.EmployeeTasks;

        public PopupDialogViewModel(EmployeeTasksRepository repository) {
            this.repository = repository;
        }

        public void PreparePopupAndOpen(EmployeeTask item, int handle) {
            ActiveItem = item;
            ItemHandle = handle;

            PopupTitle = item.Name;
            ButtonPinVisible = item.Status == TaskStatus.Uncompleted;
            ButtonDoneVisible = item.Status == TaskStatus.Urgent || item.Status == TaskStatus.Uncompleted;
            ButtonToDoVisible = item.Status == TaskStatus.Completed;

            IsOpenPopup = true;
        }

    }
}
