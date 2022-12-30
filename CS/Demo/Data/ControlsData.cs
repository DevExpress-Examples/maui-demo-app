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
                new DemoItem() {
                    Title = "Simple Button",
                    Description = "Illustrates how to customize a button.",
                    Module = typeof(SimpleButtonView),
                    Icon = "simplebutton",
                    ShowItemUnderline = false
                },
                new DemoItem() {
                    Title = "Check Edit",
                    Description = "Shows how you can customize our checkbox.",
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
        public string Title => TitleData.ControlsDataTitle;
    }
}
