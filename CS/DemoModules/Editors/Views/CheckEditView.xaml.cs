using System.Collections;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using DevExpress.Maui.DataForm;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class CheckEditView : Demo.DemoPage {
        public CheckEditView() {
            InitializeComponent();
            BindingContext = new CheckEditViewModel(this.edit);
        }
    }
}