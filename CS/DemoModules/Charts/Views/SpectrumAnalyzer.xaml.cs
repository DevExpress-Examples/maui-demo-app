using System;
using System.Timers;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class SpectrumAnalyzer : Demo.DemoPage {
        readonly LogarithmicScaleViewModel viewModel = new LogarithmicScaleViewModel();
        readonly Timer timer = new Timer();
        bool isRunning;

        public SpectrumAnalyzer() {
            InitializeComponent();
            BindingContext = viewModel;

            timer.Interval = 40;
            timer.Elapsed += Timer_Tick;
            timer.AutoReset = false;
        }

        void Timer_Tick(object sender, EventArgs e) {
            Dispatcher.Dispatch(() => {
                viewModel.MoveToNextFrame();
                if (isRunning)
                    timer.Start();
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            isRunning = false;
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            isRunning = true;
            timer.Start();
        }
    }

}
