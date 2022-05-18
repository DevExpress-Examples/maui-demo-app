
using DemoCenter.Maui.Demo.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo {
    public partial class ColorPicker : ContentView {
        public ColorPicker() {
            InitializeComponent();
        }

//        //private void OnCloseClicked(object sender, System.EventArgs e) {
//        //    IsVisible = false;
//        //}
//        //private void OnSaveClicked(object sender, System.EventArgs e) {
//        //    (BindingContext as ColorPickerModel).Color = colorsSelector.SelectedItem.Color;
//        //    IsVisible = false;
//        //}
//        protected override void OnBindingContextChanged() {
//            base.OnBindingContextChanged();
//            var pickerModel = BindingContext as ColorPickerModel;
//            //if(pickerModel != null) {
//            //    colorsSelector.Items = pickerModel.LabelModels;
//            //    colorsSelector.SelectedItem = pickerModel.SelectedItem;
//            //}
//        }
    }
}
