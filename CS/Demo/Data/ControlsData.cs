using System;
using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.Popup.Views;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class ControlsData : IDemoData {
        readonly List<DemoItem> demoItems;

        public ControlsData() {
            this.demoItems = new List<DemoItem>() {
                //new DemoItem() {
                //    Title = "Header Panel" + Environment.NewLine + "Position",
                //    ControlsPageTitle = "Header Panel Position",
                //    PageTitle = "Contacts",
                //    Description = "This demo illustrates a View that docks its header to different screen edges.",
                //    Module = typeof(PhoneListView),
                //    Icon = "tabview_headerpanelposition"
                //},
                //new DemoItem() {
                //    Title = "Data" + Environment.NewLine + "Binding",
                //    ControlsPageTitle = "Data Binding",
                //    PageTitle = "Companies",
                //    Description="The Tab View populates its tabs from an item source in this demo.",
                //    Module = typeof(CompaniesTabView),
                //    Icon = "tabview_databinding"
                //},
                //new DemoItem() {
                //    Title = "Nested" + Environment.NewLine + "Tab Views",
                //    ControlsPageTitle = "Nested Tab Views",
                //    PageTitle = "Nested Tab Views",
                //    Description = "The tab view is moved to another tab view in this demo.",
                //    Module = typeof(NestedTabView),
                //    Icon = "tabview_nestedtabsviews"
                //},
                new DemoItem() {
                    Title = "Simple Button",
                    Description = "Illustrates how to customize a button.",
                    Module = typeof(SimpleButtonView),
                    Icon = "simplebutton",
                    ShowItemUnderline = false
                },
                new DemoItem() {
                    Title = "Check Edit",
                    Description = "Demonstrates different CheckEdit customization options.",
                    Module = typeof(CheckEditView),
                    Icon = "checkedit"
                },
                new DemoItem() {
                    Title = "Chips",
                    Description = "Chips display information in a discrete and compact form. They allow users to make selections, filter content, or trigger actions.",
                    Module = typeof(ChipView),
                    Icon = "chips"
                },
                new DemoItem() {
                    Title = "Choice Chip Group",
                    Description = "Choice chips allow users to select a single option from a set. These chips are best used when only one choice is possible.",
                    Module = typeof(SuperHeroTShirtView),
                    Icon = "choicechips"
                }
            };
            this.demoItems[this.demoItems.Count - 1].ShowItemUnderline = false;
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "Controls";
    }
}
