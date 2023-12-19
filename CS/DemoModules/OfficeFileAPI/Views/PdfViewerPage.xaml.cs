using DevExpress.Maui.Pdf;

namespace DemoCenter.Maui.Views;

public partial class PdfViewerPage : Demo.DemoPage {
    public PdfViewerPage() {
        InitializeComponent();
    }

    void OnPageTap(object sender, PageTapEventArgs e) {
        pdfViewer.ShowToolbar = !pdfViewer.ShowToolbar;
        Microsoft.Maui.Controls.Shell.SetNavBarIsVisible(this, pdfViewer.ShowToolbar);
    }
}
