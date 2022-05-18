using System.Collections.Generic;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public class DemoGroupsData {
        static readonly List<DemoItem> demoItems;

        static DemoGroupsData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    IsHeader=true,
                    Title = "for .NET MAUI"
                },
                new DemoItem() {
                    Title = "Data Grid: Basic Features",
                    Description = "Data Grid: Basic Features",
                    Module = typeof(GridData)
                },
                new DemoItem() {
                    Title = "Data Grid: Advanced Features",
                    Description = "Data Grid: Advanced Features",
                    Module = typeof(DataGridAdvanced)
                },
                new DemoItem() {
                    Title = "Collection / List View",
                    Description = "CollectionView",
                    Module = typeof(CollectionViewData)
                },
                new DemoItem() {
                    Title = "Data Editors",
                    Description = "Data Editors",
                    Module = typeof(EditorsData)
                },
                new DemoItem() {
                    Title = "Buttons",
                    Description = "Buttons",
                    Module = typeof(ControlsData)
                },
                new DemoItem() {
                    Title = "Data Form, Popup, & Menu",
                    Description = "Data Form, Popup, & Menu",
                    Module = typeof(DataFormData)
                },
                new DemoItem() {
                    Title = "Charts: Basic Features",
                    Description = "Charts: Basic Features",
                    Module = typeof(ChartsData)
                },
                new DemoItem() {
                    Title = "Charts: Advanced Features",
                    Description = "Charts: Advanced Features",
                    Module = typeof(ChartsDataAdvanced)
                },
                new DemoItem() {
                    Title = "Scheduler",
                    Description = "Scheduler",
                    Module = typeof(SchedulerData)
                }
            };
         }

        public static List<DemoItem> DemoItems => demoItems;
    }
}
