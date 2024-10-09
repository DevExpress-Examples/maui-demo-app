using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;

namespace DemoCenter.Maui.Views {
    public partial class MonthViewDemo : Demo.DemoPage {
        readonly EmployeeCalendarViewModel viewModel = new EmployeeCalendarViewModel();
        bool inNavigation;

        public MonthViewDemo() {
            InitializeComponent();
            BindingContext = viewModel;
        }

        async void MonthView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation || e.IntervalInfo == null)
                return;
            viewModel.Start = e.IntervalInfo.Start;
            inNavigation = true;
            await DemoNavigationService.NavigateToPage(new DayViewModule(viewModel, this.monthView.DataStorage));
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }
    }
}
