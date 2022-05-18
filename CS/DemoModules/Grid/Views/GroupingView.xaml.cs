using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid.Localization;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class GroupingView : BaseGridContentPage {
        string TotalSummaryDisplayFormat { get; set; }
        public GroupingView() {
            AddResources();
            InitializeComponent();
            SaveGroupSummaryDisplayFormat();
        }

        void AddResources() {
            Resources.Add("IsTablet", DeviceInfo.Idiom == DeviceIdiom.Tablet);
            double minWidth;
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                minWidth = 135;
            } else {
                minWidth = 120;
            }
            Resources.Add("MinWidth", minWidth);
        }

        protected override object LoadData() {
            return new InvoicesRepository();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            SaveGroupSummaryDisplayFormat();
        }

        protected override void OnDisappearing() {
            RestoreGroupSummaryDisplayFormat();
            base.OnDisappearing();
        }

        void SaveGroupSummaryDisplayFormat() {
            TotalSummaryDisplayFormat = GridLocalizer.GetString(GridStringId.GroupSummaryDisplayFormat);
            GridLocalizer.Active.AddString(GridStringId.GroupSummaryDisplayFormat, "{0}={2}");
        }

        void RestoreGroupSummaryDisplayFormat() {
            GridLocalizer.Active.AddString(GridStringId.GroupSummaryDisplayFormat, TotalSummaryDisplayFormat);
        }
    }
}
