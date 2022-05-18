using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.CollectionView.Data;

namespace DemoCenter.Maui.ViewModels {
    public class DefaultSwipeViewModel : NotificationObject {
        readonly EmployeeTasksRepository repository;

        public IList<EmployeeTask> ItemSource => this.repository.EmployeeTasks;

        public DefaultSwipeViewModel(EmployeeTasksRepository repository) {
            this.repository = repository;
        }
    }
}
