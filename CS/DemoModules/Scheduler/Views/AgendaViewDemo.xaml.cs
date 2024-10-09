using DemoCenter.Maui.Services;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;
using System;

namespace DemoCenter.Maui.Views;

public partial class AgendaViewDemo : Demo.DemoPage {
    bool inNavigation;

    public AgendaViewDemo() {
        InitializeComponent();
    }

    void OnTodayClicked(object sender, EventArgs e) {
        agendaView.Start = DateTime.Today;
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        this.inNavigation = false;
    }

    async void OnTap(object sender, SchedulerGestureEventArgs e) {
        if (this.inNavigation)
            return;
        Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
        if (appointmentPage != null) {
            inNavigation = true;
            await DemoNavigationService.NavigateToPage(appointmentPage);
        }
    }
    async void OnNewAppointmentClicked(object sender, EventArgs e) {
        if (this.inNavigation)
            return;
        Page appointmentPage = storage.CreateAppointmentPageOnTap(agendaView.Start, false);
        if (appointmentPage != null) {
            inNavigation = true;
            await DemoNavigationService.NavigateToPage(appointmentPage);
        }
    }
}