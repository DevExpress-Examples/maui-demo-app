using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class GridData : IDemoData {
        readonly List<DemoItem> demoItems;

        public GridData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
#if PaidDemoModules
                    Title = "First Look / Data Export",
#else
                    Title = "First Look",
#endif
                    Description = "In this demo, you can try our Data Grid’s frequently-used navigation features and data presentation capabilities. Review the following functionality: columns corresponding to different data types (text, date, image), column size and position management, data grouping and sorting, vertical and horizontal scrolling, and fixed (frozen) columns. You can also export grid data to various formats (PDF, DOCX, and XLSX) and specify export options such as page size and orientation.",
                    Module = typeof(FirstLookView),
                    Icon = "firstlook"
                },
                new DemoItem() {
                    Title = "Grouping",
                    Description = "The Data Grid control can group rows against values in a specific column. Items in this demo table are grouped by the order ID. In each group row, the control displays a summary for that order. At the bottom of the table, the total summary is displayed.",
                    Module = typeof(GroupingView),
                    Icon = "grouping",
                    ShowItemUnderline = false
                },
                new DemoItem() {
                    Title = "Editing",
                    Description = "The Data Grid control supports the edit of different types of data. For each data type, it uses a specific and fully-customizable data editor. Users can edit data directly in grid cells or on a separate edit form invoked for a grid row. Use the Ellipsis menu to change edit mode.",
                    Module = typeof(EditingView),
                    Icon = "editing"
                },
                new DemoItem() {
                    Title = "Auto Filter Row",
                    Description = "Demonstrates a special row displayed at the top of the table that allows the user to filter values in a column. Values in the column can start with, contain, or equal to the entered value.",
                    Module = typeof(AutoFilterRowView),
                    Icon = "filter"
                },
                new DemoItem() {
                    Title = "Swipe Actions",
                    ControlsPageTitle = "Swipe Actions",
                    Description = "The swipe gesture allows your users to access row-related commands. Users can swipe a row to the left or right.",
                    Module = typeof(SwipeButtonsView),
                    Icon = "swipeactions"
                },
                new DemoItem() {
                    Title = "Virtual Scrolling",
                    Description = "If you enable virtual scrolling, the Data Grid control renders only columns that are currently in the viewport. This feature significantly improves the performance of tables with many columns.",
                    Module = typeof(HorizontalVirtualizationView),
                    Icon = "virtualscrolling"
                },
                new DemoItem() {
                    Title = "Pull-to-Refresh",
                    Description = "The Data Grid control supports the pull-to-refresh gesture. Drag the screen downwards and then release it to load new content.",
                    Module = typeof(PullToRefreshView),
                    Icon = "pulltorefresh"
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => TitleData.GridDataTitle;
    }
}
