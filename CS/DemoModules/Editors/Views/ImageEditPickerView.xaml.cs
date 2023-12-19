using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;

namespace DemoCenter.Maui.Views;

public partial class ImageEditPickerView : Demo.DemoPage {

    public ImageEditPickerView() {
        InitializeComponent();
    }

    private async void SelectPhotoClicked(object sender, EventArgs args) {
        try {
            var photo = await MediaPicker.PickPhotoAsync();
            await ProcessResult(photo);
        } catch (PermissionException ex) {
            await DisplayAlert("Permission Denied", ex.Message, "OK");
        }
    }

    private async void TakePhotoClicked(object sender, EventArgs args) {
        if (!MediaPicker.Default.IsCaptureSupported)
            return;

        try {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ProcessResult(photo);
        } catch (PermissionException ex) {
            await DisplayAlert("Permission Denied", ex.Message, "OK");
        }
    }

    private async Task ProcessResult(FileResult result) {
        if (result == null)
            return;

        ImageSource imageSource = null;
        if (System.IO.Path.IsPathRooted(result.FullPath))
            imageSource = ImageSource.FromFile(result.FullPath);
        else {
            imageSource = ImageSource.FromStream(() => result.OpenReadAsync().Result);
        }
        var editorPage = new ImageEditView(imageSource);
        await Navigation.PushAsync(editorPage);

        var cropResult = await editorPage.WaitForResultAsync();
        if (cropResult != null)
            preview.Source = cropResult;

        editorPage.Handler.DisconnectHandler();
    }
}