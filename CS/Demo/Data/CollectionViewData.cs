using System;
using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.CollectionView.Views;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public class CollectionViewData : IDemoData {
        public CollectionViewData() {
            DemoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "Demonstrates the DXCollectionView's basic features.",
                    Module = typeof(ContactsView),
                    Icon = "collectionview_firstlook"
                },
                new DemoItem() {
                    Title = "Swipe Actions",
                    Description = "Illustrates the UI that is extended with extra buttons when you swipe an item row.",
                    Module = typeof(CollectionViewDefaultSwipes),
                    Icon = "collectionview_swipeactions"
                },
                new DemoItem() {
                    Title = "Horizontal Scrolling",
                    Description = "Demonstrates the DXCollectionView's items Horizontal Scrolling.",
                    Module = typeof(CollectionViewHorizontalScrolling),
                    Icon = "collectionview_virtualscrolling"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "Shows how the list can automatically adjust item height to display the entire content of items.",
                    Module = typeof(CollectionViewRowAutoHeightView),
                    Icon = "collectionview_rowautoheight"
                },
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Demonstrates the list's drag-and-drop functionality. This feature allows users to reorder items.",
                    Module = typeof(CollectionViewDragDropView),
                    Icon = "collectionview_dragdrop"
                },
                new DemoItem() {
                    Title = "Pull To Refresh",
                    Description = "Shows how end users can use a pull-down gesture to update the list.",
                    Module = typeof(CollectionViewPullToRefreshView),
                    Icon = "collectionview_pulltorefresh"
                },
                new DemoItem() {
                    Title = "Infinite Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "Shows how the list requests new data when users scroll to the end of the list.",
                    Module = typeof(CollectionViewLoadMoreView),
                    Icon = "collectionview_infinitedatasource",
                    ShowItemUnderline = false
                }
            };
        }

        public List<DemoItem> DemoItems { get; }
        public string Title => "CollectionView";
    }
}
