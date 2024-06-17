using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class EmployeesRepository {
        public IList<Employee> Employees { get; private set; }

        public EmployeesRepository() {
            System.Reflection.Assembly assembly = GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Employees.json");
            Employees = JsonSerializer.Deserialize<List<Employee>>(stream, TrimmableContext.Default.ListEmployee);
        }
    }
}
