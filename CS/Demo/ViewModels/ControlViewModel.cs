using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Services;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class ControlViewModel : BaseViewModel, IQueryAttributable {
        IDemoData data;
        DemoItem selectedItem;
        public List<DemoItem> DemoItems => this.data?.DemoItems;
        public DemoItem SelectedItem {
            get => this.selectedItem;
            set {
                SetProperty(ref this.selectedItem, value);
                if (this.selectedItem == null)
                    return;
                NavigationDemoCommand.Execute(this.selectedItem);
            }
        }
        public ICommand NavigationDemoCommand { get; }

        public ControlViewModel() {
            NavigationDemoCommand = new Command<DemoItem>(async (demoItem) => {
                await DemoNavigationService.NavigateToDemo(demoItem);
                SelectedItem = null;
            });
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            if (query.TryGetValue("DemoData", out object data)) {
                SetProperty(ref this.data, data as IDemoData, propertyName: nameof(DemoItems));
            }
        }
    }
}
