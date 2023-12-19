using System;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views;

public partial class EditBioPage : DemoPage {
    SettingsFormViewModel settings;
    public SettingsFormViewModel Settings {
        get => this.settings;
        set {
            this.settings = value;
            this.bioEditor.Text = value.Bio;
        }
    }
    public EditBioPage() {
        InitializeComponent();
    }

    async void OnAccept(object sender, EventArgs e) {
        Settings.Bio = this.bioEditor.Text;
        await Shell.Current.Navigation.PopAsync();
    }

    void OnEditorLoaded(object sender, EventArgs e) {
        this.bioEditor.Focus();
    }
}