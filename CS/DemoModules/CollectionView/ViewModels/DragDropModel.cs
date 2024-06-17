using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.DemoModules.CollectionView.Data;

namespace DemoCenter.Maui.ViewModels {
    public class DragDropModel : NotificationObject {
        readonly EmployeeTasksRepository repository;

        public IList<EmployeeTask> ItemSource => this.repository.EmployeeTasks;

        public DragDropModel(EmployeeTasksRepository repository) {
            this.repository = repository;
        }
    }
}
