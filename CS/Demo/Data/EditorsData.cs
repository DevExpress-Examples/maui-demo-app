using System;
using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class EditorsData : IDemoData {
        readonly List<DemoItem> demoItems;

        public EditorsData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description="Shows the TextEdit, PasswordEdit, MultilineEdit, and SimpleButton editors on a registration form.",
                    Module = typeof(AccountFormView),
                    Icon = "editors"
                },
                new DemoItem() {
                    Title = "Combo Box",
                    Description = "Shows how to customize the ComboBoxEdit.",
                    Module = typeof(ComboBoxEditView),
                    Icon = "combobox"
                },
                new DemoItem() {
                    Title = "Auto Complete",
                    ControlsPageTitle = "Text Editor with Autocomplete",
                    Description = "Shows how to customize the AutoCompleteEdit.",
                    Module = typeof(AutoCompleteEditAsyncView),
                    Icon = "autocomplete"
                },
                new DemoItem() {
                    Title = "Phone Book",
                    PageTitle = "Phone Number Editor"+Environment.NewLine+"with Autocomplete",
                    ControlsPageTitle = "Phone Book with Autocomplete",
                    Description = "Shows how to use the AutoCompleteEdit in a phone book.",
                    Module = typeof(AutoCompleteEditView),
                    Icon = "phonebook"
                },
                new DemoItem() {
                    Title = "Text Edit",
                    Description = "Demonstrates different TextEdit customization options.",
                    Module = typeof(TextEditView),
                    DemoItemStatus = DemoItemStatus.Updated,
                    Icon = "textedit"
                },
                new DemoItem() {
                    Title = "Numeric Edit",
                    Description = "Demonstrates different NumericEdit customization options.",
                    Module = typeof(NumericEditView),
                    Icon = "numericedit"
                },
                new DemoItem() {
                    Title = "Date Edit",
                    Description = "Demonstrates different DateEdit customization options.",
                    Module = typeof(DateEditView),
                    Icon = "dateedit"
                },
                new DemoItem() {
                    Title = "Time Edit",
                    Description = "Demonstrates different TimeEdit customization options.",
                    Module = typeof(TimeEditView),
                    Icon = "timeedit"
                }
            };
        }

        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "Editors";
    }
}
