using System;
using DevExpress.Maui.TreeView;
using DevExpress.Maui.Editors;
using DemoCenter.Maui.DemoModules.TreeView.Data;
using DemoCenter.Maui.DemoModules.TreeView.ViewModels;
using Microsoft.Maui.Graphics;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.TreeView.Views;

public partial class FirstLookPage : Demo.DemoPage {
    public FirstLookPage() {
        InitializeComponent();
        UpdateSelectionButton();
#if PaidDemoModules
        var pdf = new DevExpress.Maui.Pdf.PdfViewer() {
            ShowToolbar = false,
            ShowEditToolbar = false,
            ShowPageCounter = false,
            DisplayMode = DevExpress.Maui.Pdf.PdfViewerDisplayMode.SinglePage,
            BackgroundColor = Colors.Transparent
        };
        pdfViewerContainer.Children.Add(pdf);
#endif
    }
    void OnSearchTextChanged(object sender, EventArgs e) {
        string searchText = ((TextEdit)sender).Text;
        this.treeView.FilterString =
            string.IsNullOrEmpty(searchText)
            ? null
            : $"Contains([Name], '{searchText}')";
    }
    void OnNodeTap(object sender, TreeNodeEventArgs e) {
#if PaidDemoModules
        if(pdfViewerContainer.Children.Count == 0) 
            return;
        var vm = (FirstLookPageViewModel)BindingContext;
        if (vm.IsSelectMode)
            return;
        var pdf = (DevExpress.Maui.Pdf.PdfViewer)pdfViewerContainer.Children[0];
        var n = (ReportLibraryNode)e.Node.Item;
        var fileName = ReportLibraryNode.GetFileName(n);
        if (string.IsNullOrEmpty(fileName))
            return;
        pdfCaption.Text = n.Name;
        pdf.DocumentSource = fileName;
        detailBottomSheet.Show();
#endif
    }
    void OnTreeNodeCheckBoxStateChanged(object sender, TreeNodeCheckBoxStateChangedEventArgs e) {
        var vm = (FirstLookPageViewModel)BindingContext;
        if (e.OldState == true)
            vm.RemoveCheckedNode((ReportLibraryNode)e.Node.Item);
        if(e.NewState == true)
            vm.AddCheckedNode((ReportLibraryNode)e.Node.Item);
    }
    void OnSelectionButtonClicked(object sender, EventArgs e) {
        UpdateSelectionButton();
    }
    void UpdateSelectionButton() {
        if(ON.iOS)
            return;
        var vm = (FirstLookPageViewModel)BindingContext;
        selectionButton.IconImageSource = vm.IsSelectMode
            ? new FontImageSource() { Glyph = "Cancel" }
            : new FontImageSource() { Glyph = "Select" };
    }
}