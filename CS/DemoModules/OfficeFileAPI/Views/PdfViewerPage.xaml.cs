using DevExpress.Maui.Pdf;

namespace DemoCenter.Maui.Views;

public partial class PdfViewerPage : Demo.DemoPage {
    public PdfViewerPage() {
        InitializeComponent();
    }

#if IOS
    protected override void OnAppearing() {
        base.OnAppearing();
        Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Disconnect();
    }

    protected override void OnDisappearing() {
        base.OnDisappearing();
        Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Connect();
    }
#endif

    void OnPageTap(object sender, PageTapEventArgs e) {
        pdfViewer.ShowToolbar = !pdfViewer.ShowToolbar;
        Microsoft.Maui.Controls.Shell.SetNavBarIsVisible(this, pdfViewer.ShowToolbar);
    }
}
