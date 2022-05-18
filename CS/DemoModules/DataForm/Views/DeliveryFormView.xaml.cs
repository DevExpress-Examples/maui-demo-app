using System;
using DemoCenter.Maui.DemoModules.DataForm.ViewModels;
using DevExpress.Maui.DataForm;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class DeliveryFormView : ContentPage {
        public DeliveryFormView() {
            InitializeComponent();
            BindingContext = new DeliveryFormViewModel();
            dataForm.ValidateProperty += DataFormOnValidateProperty;
        }

        void DataFormOnValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
            if (e.PropertyName == nameof(DeliveryInfo.DeliveryTimeFrom)) {
                ((DeliveryInfo) dataForm.DataObject).DeliveryTimeFrom = (DateTime)e.NewValue;
                Device.BeginInvokeOnMainThread(() => {
                    dataForm.Validate(nameof(DeliveryInfo.DeliveryTimeTo));    
                });
            }
            if (e.PropertyName == nameof(DeliveryInfo.DeliveryTimeTo)) {
                DateTime timeFrom = ((DeliveryInfo) dataForm.DataObject).DeliveryTimeFrom;
                if(timeFrom > (DateTime)e.NewValue) {
                    e.HasError = true;
                    e.ErrorText = "The end time cannot be less than the start time";
                    return;
                }
            }
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            ((DeliveryFormViewModel) this.BindingContext).Rotate(dataForm, height > width);            
        }

        private void SubmitOnClicked(object sender, EventArgs e) {
            dataForm.Commit();
            if (dataForm.Validate()) 
                DisplayAlert("Success", "Your delivery information has been successfully saved", "OK");
        }

        void DataFormDateItem_PickerDisableDate(object sender, DisableDateEventArgs e) {
            if (e.Date.DayOfWeek == DayOfWeek.Sunday || e.Date.DayOfWeek == DayOfWeek.Saturday) {
                e.IsDisabled = true;
            }
        }

        void DataForm_GeneratePropertyItem(object sender, DataFormPropertyGenerationEventArgs e) {
            if (e.Item.FieldName == nameof(DeliveryFormViewModel.Model.DeliveryDate) && e.Item is DataFormDateItem item) {
                item.PickerDisableDate += DataFormDateItem_PickerDisableDate;
            }
        }        
    }
}
