using System;
using System.Timers;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class Oscillator : ContentPage {
        readonly OscillatorChartsViewModel viewModel = new OscillatorChartsViewModel();
        readonly Timer timer = new Timer();
        bool isRunning = false;

        public Oscillator() {
            
            InitializeComponent();
            BindingContext = viewModel;

            timer.Interval = 20;
            timer.Elapsed += Timer_Tick;
            timer.AutoReset = false;
        }

        void Timer_Tick(object sender, EventArgs e) {
            Device.BeginInvokeOnMainThread(() => {
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
