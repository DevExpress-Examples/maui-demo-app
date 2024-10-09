using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Data {
    public enum TaskStatus {
        Urgent = 0,
        Uncompleted = 1,
        Completed = 2
    }
    public class EmployeeTasksObject {
        public List<EmployeeTask> EmployeeTasks { get; set; }
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

        int statusNumber;
        public int StatusNumber {
            get => statusNumber;
            set {
                statusNumber = value;
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(Completed));
            }
        }

        [JsonIgnore] public ICommand UrgentTaskCommand { get; }
        [JsonIgnore] public ICommand CompleteTaskCommand { get; }
        [JsonIgnore] public ICommand UnCompleteTaskCommand { get; }

        [JsonIgnore]
        public TaskStatus Status {
            get => StatusNumber switch {
                0 => TaskStatus.Urgent,
                2 => TaskStatus.Completed,
                _ => TaskStatus.Uncompleted
            };
            set => SetProperty(ref statusNumber, (int)value);
        }
        [JsonIgnore] public bool Completed => Status == TaskStatus.Completed;
    }
}
