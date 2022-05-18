using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class MonthViewDemo : ContentPage {
        readonly EmployeeCalendarViewModel viewModel = new EmployeeCalendarViewModel();
        bool inNavigation = false;

        public MonthViewDemo() {
            InitializeComponent();
            BindingContext = viewModel;
        }
        
        void MonthView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation || e.IntervalInfo == null)
                return;
            viewModel.Start = e.IntervalInfo.Start;
            inNavigation = true;
            Navigation.PushAsync(new DayViewModule(viewModel, this.monthView.DataStorage));
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }
    }
}
