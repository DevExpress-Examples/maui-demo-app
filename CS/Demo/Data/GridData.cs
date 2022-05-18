using System;
using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class GridData : IDemoData {
        readonly List<DemoItem> demoItems;

        public GridData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "Demonstrates the DataGridView’s basic features.",
                    Module = typeof(FirstLookView),
                    Icon = "firstlook"
                },
                new DemoItem() {
                    Title = "Grouping",
                    Description = "Illustrates how the grid groups data against a column and calculates data summaries.",
                    Module = typeof(GroupingView),
                    Icon = "grouping",
                    ShowItemUnderline = false
                },
                new DemoItem() {
                    Title = "Editing",
                    Description = "Demonstrates the grid’s inplace data editors.",
                    Module = typeof(EditingView),
                    Icon = "editing"
                },
                new DemoItem() {
                    Title = "Auto Filter Row",
                    Description = "Demonstrates the Auto Filter Row that supports a straightforward search for data in columns.",
                    Module = typeof(AutoFilterRowView),
                    Icon = "filter"
                },
                new DemoItem() {
                    Title = "Swipe Actions",
                    ControlsPageTitle = "Swipe Actions",
                    Description = "Illustrates the UI that is extended with extra buttons when you swipe a data row.",
                    Module = typeof(SwipeButtonsView),
                    Icon = "swipeactions"
                },
                new DemoItem() {
                    Title = "Virtual Scrolling",
                    Description = "Demonstrates the virtual scrolling feature, which significantly improves the performance of grids with many columns.",
                    Module = typeof(HorizontalVirtualizationView),
                    Icon = "virtualscrolling"
                },
                new DemoItem() {
                    Title = "Pull To Refresh",
                    Description = "Shows how to update the grid’s content with the pull-down gesture.",
                    Module = typeof(PullToRefreshView),
                    Icon = "pulltorefresh"
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "DataGridView";
    }
}
