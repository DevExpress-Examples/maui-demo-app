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
                    Description="You can use our editors to create a data form. This registration form allows a user to enter a login, password, date, and notes.",
                    Module = typeof(AccountFormView),
                    Icon = "editors"
                },
                new DemoItem() {
                    Title = "Equalizer",
                    Description = "Demonstrates how to emulate equalizer UI with the help of DevExpress DXSlider and DXRangeSlider controls. These controls allow you to specify custom value ranges and change track orientation. You can customize the appearance of the track, thumbs, and tick marks.",
                    Module = typeof(SlidersView),
                    Icon = "equalizer",
                    DemoItemStatus = DemoItemStatus.New,
                },
#if PaidDemoModules
                new DemoItem() {
                    Title = "Html Edit",
                    Description="Demonstrates how to use DevExpress HTML Edit control to replicate email client UI. The editor allows you to modify and format text, insert images, and add hyperlinks.",
                    Module = typeof(HtmlEditView),
                    Icon = "htmledit",
                },
#endif
                new DemoItem() {
                    Title = "Image Edit",
                    Description="Demonstrates an avatar customization page created with the help of our image editor. The editor allows you to crop, flip, and rotate images. You can save the result in PNG and JPEG formats.",
                    Module = typeof(ImageEditPickerView),
                    Icon="imageedit",
                },
                new DemoItem() {
                    Title = "Settings Form",
                    Description="Demonstrates how to implement a settings form with the help of our editors. This form contains switches, text editors, and picker controls.",
                    Module = typeof(SettingsForm),
                    Icon = "settingsform",
                },
                new DemoItem() {
                    Title = "Deployment Form",
                    Description="Shows how to use our token editors to create an app deployment form. Token editors allow you to select multiple items from a list.",
                    Module = typeof(ApplicationDeploymentForm),
                    Icon="deploymentform",
                },
                new DemoItem() {
                    Title = "Combo Box",
                    Description = "Demonstrates the customization capabilities of our combo box.",
                    Module = typeof(ComboBoxEditView),
                    Icon = "combobox"
                },
                new DemoItem() {
                    Title = "Auto Complete",
                    ControlsPageTitle = "Text Editor with Autocomplete",
                    Description = "Shows how you can customize our text editor with the autocomplete feature.",
                    Module = typeof(AutoCompleteEditAsyncView),
                    Icon = "autocomplete"
                },
                new DemoItem() {
                    Title = "Phone Book",
                    PageTitle = "Phone Number Editor"+Environment.NewLine+"with Autocomplete",
                    ControlsPageTitle = "Phone Book with Autocomplete",
                    Description = "Shows how to use the text editor with autocomplete in a phone book.",
                    Module = typeof(AutoCompleteEditView),
                    Icon = "phonebook"
                },
                new DemoItem() {
                    Title = "Text Edit",
                    Description = "Demonstrates the customization capabilities of our text editor.",
                    Module = typeof(TextEditView),
                    Icon = "textedit"
                },
                new DemoItem() {
                    Title = "Numeric Edit",
                    Description = "Demonstrates the customization capabilities of our numeric editor.",
                    Module = typeof(NumericEditView),
                    Icon = "numericedit"
                },
                new DemoItem() {
                    Title = "Date Edit",
                    Description = "Shows how you can customize our date editor.",
                    Module = typeof(DateEditView),
                    Icon = "dateedit"
                },
                new DemoItem() {
                    Title = "Time Edit",
                    Description = "Demonstrates the customization capabilities of our time editor.",
                    Module = typeof(TimeEditView),
                    Icon = "timeedit"
                }
            };
        }

        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => TitleData.EditorsDataTitle;
    }
}
