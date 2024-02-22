using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.CollectionView.Views;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public class CollectionViewData : IDemoData {
        public CollectionViewData() {
            DemoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "An introduction to our Collection View control. Shows basic control features, such as vertical orientation, grouping, and item templates.",
                    Module = typeof(ContactsView),
                    Icon = "collectionview_firstlook"
                },
                new DemoItem() {
                    Title = "Filtering UI",
                    Description = "Shows built-in filtering UI available in our Collection View control. Users can apply filter conditions to individual columns or to the entire control (construct a filter criteria of any complexity).",
                    Module = typeof(FilteringUIView),
                    Icon = "collectionview_filteringui",
                    DemoItemStatus = DemoItemStatus.Updated
                },
                new DemoItem() {
                    Title = "CRUD Operations",
                    Description = "This demo implements a contact list. The list’s bound data source contains a few pre-defined contacts. You can edit existing records and add new people to the list. In both cases, you use the same contact edit form. Enter invalid values into editors on the form to see how our editors validate user input.",
                    Module = typeof(ContactsCRUDView),
                    Icon = "collectionview_contactscrud",
                },
                new DemoItem() {
                    Title = "Swipe Actions",
                    Description = "The swipe gesture allows your users to access row-related commands. Users can swipe a row to the left or right.",
                    Module = typeof(CollectionViewDefaultSwipes),
                    Icon = "collectionview_swipeactions"
                },
                new DemoItem() {
                    Title = "Horizontal Scrolling",
                    Description = "You can arrange elements horizontally in the view. In combination with item templates, this allows you to implement a gallery of items with our Collection View control.",
                    Module = typeof(CollectionViewHorizontalScrolling),
                    Icon = "collectionview_virtualscrolling"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "Our Collection View control automatically adjusts row heights to fully display the content of cells. You can always set the height to a fixed value.",
                    Module = typeof(CollectionViewRowAutoHeightView),
                    Icon = "collectionview_rowautoheight"
                },
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Users can drag a row to a new position. Touch and hold a row to start dragging it.",
                    Module = typeof(CollectionViewDragDropView),
                    Icon = "collectionview_dragdrop"
                },
                new DemoItem() {
                    Title = "Pull-to-Refresh",
                    Description = "The Collection View control supports the pull-to-refresh gesture. Drag the screen downwards and then release it to load new content.",
                    Module = typeof(CollectionViewPullToRefreshView),
                    Icon = "collectionview_pulltorefresh"
                },
                new DemoItem() {
                    Title = "Infinite Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "You can implement infinite scrolling in the Collection View control. This allows you to speed up the display of large data sources. The control only shows more rows if the user scrolls down to the bottom of the page.",
                    Module = typeof(CollectionViewLoadMoreView),
                    Icon = "collectionview_infinitedatasource",
                    ShowItemUnderline = false
                }
            };
        }

        public List<DemoItem> DemoItems { get; }
        public string Title => TitleData.CollectionViewDataTitle;
    }
}
