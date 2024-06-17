using System.Collections.ObjectModel;
using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.DemoModules.TreeView.ViewModels;

public class SelfReferenceDataViewModel {
    public ObservableCollection<Employee> Nodes { get; }
    public SelfReferenceDataViewModel() {
        var r = new EmployeesRepository();
        Nodes = new(r.Employees);
    }
}