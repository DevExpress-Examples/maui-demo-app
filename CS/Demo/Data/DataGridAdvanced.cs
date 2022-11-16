using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class DataGridAdvanced : IDemoData {
        readonly List<DemoItem> demoItems;

        public DataGridAdvanced()  {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Users can drag a row to a new position. Touch and hold a row to start dragging it.",
                    Module = typeof(DragDropView),
                    Icon = "dragdrop"
                },
                new DemoItem() {
                    Title = "Advanced Layout",
                    Description = "The Data Grid control supports column layouts of any complexity. You can arrange data in your table so that it is easier for your customers to read it.",
                    Module = typeof(AdvancedLayoutView),
                    Icon = "advancedlayout"
                },
                new DemoItem() {
                    Title = "Custom Appearance",
                    Description = "You can customize the appearance of specific rows and cells based on their position, values, or any other logic.",
                    Module = typeof(CustomAppearanceView),
                    Icon = "customappearance"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "The Data Grid control automatically adjusts row heights to fully display the content of cells. You can always set the height to a fixed value.",
                    Module = typeof(RowAutoHeightView),
                    Icon = "rowautoheight"
                },
                new DemoItem() {
                    Title = "Real-Time Data",
                    Description = "The Data Grid control updates its contents if the data source changes. The control also updates the row order if changes are made to a sorted column.",
                    Module = typeof(RealTimeDataView),
                    Icon = "realtimedata"
                },
                new DemoItem() {
                    Title = "Infinite Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "You can implement infinite scrolling in the Data Grid control. This allows you to speed up the display of large data sources. The control only shows more rows if the user scrolls down to the bottom of the page.",
                    Module = typeof(LoadMoreView),
                    Icon = "infinitedatasource"
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => TitleData.DataGridAdvancedTitle;
    }
}

