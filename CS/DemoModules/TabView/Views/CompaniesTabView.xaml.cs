using System;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class CompaniesTabView : ContentPage {
        public CompaniesTabView() {
            InitializeComponent();
            BindingContext = new CompaniesTabViewModel();
        }

        void UpdateSizeChanged(object sender, EventArgs e) {
            Image image = (Image)sender;
            ResizeImageParent(image);

            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
                UpdateItemSize(image.Width);
        }

        void ResizeImageParent(Image image) {
            Grid parent = (Grid)image.Parent;

            double summaryHeight = 0;
            foreach (View subView in parent.Children)
                summaryHeight += subView.Height + subView.Margin.Top + subView.Margin.Bottom;
            summaryHeight += parent.RowSpacing * (parent.Children.Count - 1);

            if (summaryHeight > 0) {
                parent.HeightRequest = summaryHeight;
                parent.LayoutTo(new Rect(parent.Bounds.Left, parent.Bounds.Top, parent.Width, summaryHeight));
            }
        }

        void UpdateItemSize(double width) {
            int count = this.tabControl.Items.Count;

            if (count != 0) {
                double itemWidth = width / count;
                for (int i = 0; i < count; i++)
                    this.tabControl.Items[i].HeaderWidth = itemWidth;
            }
        }
    }
}
