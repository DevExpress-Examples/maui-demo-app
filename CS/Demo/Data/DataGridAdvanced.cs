using System;
using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class DataGridAdvanced : IDemoData {
        readonly List<DemoItem> demoItems;

        public DataGridAdvanced()  {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Demonstrates the grid's drag-and-drop functionality that allows users to reorder rows.",
                    Module = typeof(DragDropView),
                    Icon = "dragdrop"
                },
                new DemoItem() {
                    Title = "Advanced Layout",
                    Description = "Demonstrates how the grid arranges data cells and column headers across multiple rows.",
                    Module = typeof(AdvancedLayoutView),
                    Icon = "advancedlayout"
                },
                new DemoItem() {
                    Title = "Custom Appearance",
                    Description = "Shows how to customize the appearance of individual data cells.",
                    Module = typeof(CustomAppearanceView),
                    Icon = "customappearance"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "Shows how the grid can automatically adjust row height to display the entire content of cells.",
                    Module = typeof(RowAutoHeightView),
                    Icon = "rowautoheight"
                },
                new DemoItem() {
                    Title = "Real-Time Data",
                    Description = "Demonstrates a grid view that automatically displays new data when the data source changes.",
                    Module = typeof(RealTimeDataView),
                    Icon = "realtimedata"
                },
                new DemoItem() {
                    Title = "Infinite Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "Shows how the grid requests new data when users scroll the grid to the end.",
                    Module = typeof(LoadMoreView),
                    Icon = "infinitedatasource"
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "DataGridView";
    }
}

