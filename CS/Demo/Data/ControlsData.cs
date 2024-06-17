using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class ControlsData : IDemoData {
        readonly List<DemoItem> demoItems;

        public ControlsData() {
            this.demoItems = new List<DemoItem>() {
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                new DemoItem() {
                    Title = "Slide View",
                    Description = "Shows the SlideView control that allows users to navigate between slides. Each slide in this demo is a flash card that highlights a SlideView property. You can toggle the switch at the bottom to see how the property affects the control.",
                    DemoItemStatus = DemoItemStatus.New,
                    Module = typeof(SlideViewDemo),
                    Icon = "slideview"
                },
                new DemoItem() {
                    Title = "Toolbar Control",
                    Description = "Demonstrates how to use DevExpress Toolbar control to create compact and adaptive action bars. The toolbar in this demo includes regular toolbar buttons, dropdowns, and a color picker. The control organizes commands into pages.",
                    Module = typeof(ToolbarView),
                    Icon = "edit"
                },
                new DemoItem() {
                    Title = "Radial Gauge",
                    Description = "Shows how to use DevExpress radial gauge and progress bar components to implement a dashboard panel. In this demo, the dashboard monitors appliances and sensors in a smart home. To align gauges on screen, we use DevExpress layout controls - DXStackLayout and DXDockLayout.",
                    Icon = "radialgauge",
                    Module = typeof(RadialGaugeView)
                },
                new DemoItem() {
                    Title = "Radial Progress Bar",
                    Description = "Shows how to use the RadialProgressBar control to implement a test monitoring app.",
                    Icon = "progressbar",
                    Module = typeof(RadialProgressBarView)
                },
                new DemoItem() {
                    Title = "Loading View",
                    Description = "This demo emulates an app that obtains its data from a remote server. While a load operation is in progress, the app switches to a Loading View. This view displays a skeleton layout with UI element placeholders with shimmer effects.",
                    Icon = "shimmer",
                    Module = typeof(ShimmerView),
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
