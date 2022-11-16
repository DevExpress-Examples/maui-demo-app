using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class AutoCompleteEditAsyncView : Demo.DemoPage {
        private IList<Employee> employees;


        public AutoCompleteEditAsyncView() {
            InitializeComponent();
            this.employees = new EmployeesRepository().Employees;
        }

        void OnAsyncItemsSourceProviderItemsRequested(object sender, ItemsRequestEventArgs e) {
            e.Request = () => {
                Task.Delay(1500).Wait();
                return this.employees.Where(employee => employee.FullName.Contains(e.Text));
            };
        }
    }
}
