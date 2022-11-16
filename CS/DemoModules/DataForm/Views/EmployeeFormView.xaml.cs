﻿using System;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.DemoModules.DataForm.ViewModels;
using DevExpress.Maui.DataForm;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class EmployeeFormView : AdaptivePage {
        readonly EmployeeFormViewModel viewModel;

        public EmployeeFormView() {
            AddResources();
            InitializeComponent();
            this.viewModel = new EmployeeFormViewModel();
            BindingContext = this.viewModel;
            OrientationChanged += OnOrientationChanged;
        }

        void AddResources() {
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                Resources.Add("EditorLabelFontSize", 16);
                Resources.Add("EditorHorizontalSpacing", 24);
                Resources.Add("EditorMinWidth", 212.0);
                Resources.Add("PhotoFrameSizeRequest", 202.0);
                Resources.Add("InternalPhotoFrameSizeRequest", 200.0);
            } else {
                Resources.Add("EditorLabelFontSize", 14);
                Resources.Add("EditorHorizontalSpacing", 10);
                Resources.Add("EditorMinWidth", 192.0);
                Resources.Add("PhotoFrameSizeRequest", 162.0);
                Resources.Add("InternalPhotoFrameSizeRequest", 160.0);
            }
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            bool isVertical = Orientation == PageOrientation.Portrait;

            if (isVertical && DeviceInfo.Idiom == DeviceIdiom.Phone) {
                this.photoContainer.Margin = new Thickness(0, 0, 0, 0);
            } else if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                this.photoContainer.Margin = new Thickness(0, 25, 0, 25);
            } else {
                this.photoContainer.Margin = new Thickness(0, 50, 0, 50);
            }

            this.viewModel.Rotate(this.dataForm, isVertical);
        }
    }
}
