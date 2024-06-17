using System;
using DevExpress.Maui.Core;

namespace DemoCenter.Maui.DemoModules.TreeView.Views;

public partial class SelfReferenceDataPage : Demo.DemoPage {
    public SelfReferenceDataPage() {
        InitializeComponent();
    }
    void OnSortToolbarItemClicked(object sender, EventArgs e) {
        bool isAscending = sortDescription.SortOrder == DataSortOrder.Ascending;
        sortDescription.SortOrder = isAscending ? DataSortOrder.Descending : DataSortOrder.Ascending;
    }
}