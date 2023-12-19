using System;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.DemoModules.DataForm.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class DataFormAccountFormView : AdaptivePage {
        public DataFormAccountFormView() {
            InitializeComponent();
            BindingContext = new AccountFormViewModel();
            OrientationChanged += OnOrientationChanged;
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            ((AccountFormViewModel)this.BindingContext).Rotate(dataForm, Orientation);
        }

        void SubmitOnClicked(object sender, EventArgs e) {
            if (dataForm.Validate()) {
                dataForm.Commit();
                DisplayAlert("Success", "Your account has been created successfully", "OK");
            }
        }
    }
}
