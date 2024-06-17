using System.Collections.Generic;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public class TreeViewData : IDemoData {
        public TreeViewData() {
            DemoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "An introduction to our Tree View Control. Shows basic control features such as filtering, check boxes, swipe gestures, and item templates.",
                    Module = typeof(DemoModules.TreeView.Views.FirstLookPage),
                    DemoItemStatus = DemoItemStatus.New,
                    Icon = "treeview_firstlook"
                },
                new DemoItem() {
                    Title = "Self-Referential Data",
                    Description = "Creates a self referential data structure and displays it within the Tree View Control.",
                    Module = typeof(DemoModules.TreeView.Views.SelfReferenceDataPage),
                    DemoItemStatus = DemoItemStatus.New,
                    Icon = "treeview_selfreference"
                },
            };
        }

        public List<DemoItem> DemoItems { get; }
        public string Title => TitleData.TreeViewDataTitle;
    }
}
