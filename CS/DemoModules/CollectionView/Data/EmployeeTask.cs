using System;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data {
    public enum TaskStatus {
        Urgent = 0,
        Uncompleted = 1,
        Completed = 2
    }

    public class EmployeeTask : NotificationObject {
        public EmployeeTask() {
            UrgentTaskCommand = new Command(() => Status = TaskStatus.Urgent);
            CompleteTaskCommand = new Command(() => Status = TaskStatus.Completed);
            UnCompleteTaskCommand = new Command(() => Status = TaskStatus.Uncompleted);
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }

        public ICommand UrgentTaskCommand { get; }
        public ICommand CompleteTaskCommand { get; }
        public ICommand UnCompleteTaskCommand { get; }

        TaskStatus status;
        public TaskStatus Status {
            get => this.status;
            set => SetProperty(ref this.status, value);
        }
    }
}
