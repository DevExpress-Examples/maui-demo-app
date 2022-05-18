using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.Popup.Views;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class DataFormData : IDemoData {
        readonly List<DemoItem> demoItems;

        public DataFormData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Action Sheet",
                    Description = "A popup dialog is a floating window that appears on top of the current view and prevents access to it.",
                    Module = typeof(PopupDialogView),
                    Icon = "popupdialog"
                },
                new DemoItem() {
                    Title = "Context Menu",
                    Description = "Shows how to implement a context menu that appears when a user taps a button.",
                    Module = typeof(ContactsDropdownView),
                    Icon = "popupdropdown"
                },
                new DemoItem() {
                    Title = "Delivery Form",
                    Description = "A delivery form with a filled box style.",
                    Module = typeof(DeliveryFormView),
                    Icon = "deliveryform"
                },
                new DemoItem() {
                    Title = "Account Form",
                    Description = "An account form with an outlined box style.",
                    Module = typeof(DataFormAccountFormView),
                    Icon = "accountform"
                }
                ,
                new DemoItem() {
                    Title = "Employee Form",
                    Description = "An employee form with an outlined box style.",
                    Module = typeof(EmployeeFormView),
                    Icon = "employeeform",
                    ShowItemUnderline = false
                }
            };
        }

        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "Editors";
    }
}
