using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class EmployeesRepository {
        public IList<Employee> Employees { get; private set; }

        public EmployeesRepository() {
            System.Reflection.Assembly assembly = GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Employees.json");
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            Employees = jObject["Employees"].ToObject<List<Employee>>();
        }
    }
}
