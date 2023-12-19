using System.Collections.Generic;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public class DemoGroupsData {
        static readonly List<DemoItem> demoItems;

        static DemoGroupsData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = TitleData.CollectionViewDataTitle,
                    Description = "CollectionView",
                    Module = typeof(CollectionViewData)
                },
                new DemoItem() {
                    Title = TitleData.GridDataTitle,
                    Description = "Data Grid: Basic Features",
                    Module = typeof(GridData)
                },
                new DemoItem() {
                    Title = TitleData.DataGridAdvancedTitle,
                    Description = "Data Grid: Advanced Features",
                    Module = typeof(DataGridAdvanced)
                },
                new DemoItem() {
                    Title = TitleData.ChartsDataTitle,
                    Description = "Charts: Basic Features",
                    Module = typeof(ChartsData)
                },
                new DemoItem() {
                    Title = TitleData.ChartsDataAdvancedTitle,
                    Description = "Charts: Advanced Features",
                    Module = typeof(ChartsDataAdvanced)
                },
#if PaidDemoModules
                new DemoItem() {
                    Title = TitleData.OfficeFileAPIDataTitle,
                    Description = "Office File API",
                    Module = typeof(OfficeFileAPIData)
                },
# endif
                new DemoItem() {
                    Title = TitleData.SchedulerDataTitle,
                    Description = "Scheduler",
                    Module = typeof(SchedulerData)
                },
                new DemoItem() {
                    Title = TitleData.ControlsDataTitle,
                    Description = "Buttons",
                    Module = typeof(ControlsData)
                },
                new DemoItem() {
                    Title = TitleData.EditorsDataTitle,
                    Description = "Data Editors",
                    Module = typeof(EditorsData)
                },
                new DemoItem() {
                    Title = TitleData.DataFormDataTitle,
                    Description = "Data Form, Popup, & Menu",
                    Module = typeof(DataFormData)
                },
            };
        }
        public static List<DemoItem> DemoItems => demoItems;
    }
}