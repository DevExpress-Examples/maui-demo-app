using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.Models {
    public class DemoItem {
        string pageTitle = null;
        string icon = null;
        string controlsPageTitle = null;
        Type module;
        List<DemoItem> demoItems;

        public string Icon {
            get => String.IsNullOrEmpty(this.icon) ? "default_icon" : this.icon;
            set => this.icon = value;
        }
        public bool IsHeader { get; set; }
        public string Title { get; set; }
        public string PageTitle {
            get => this.pageTitle ?? ControlsPageTitle;
            set => this.pageTitle = value;
        }
        public string ControlsPageTitle {
            get => this.controlsPageTitle ?? Title;
            set => this.controlsPageTitle = value;
        }
        public string Description { get; set; }

        public Type Module {
            get => this.module;
            set {
                this.module = value;
                if (value != null && value.GetInterface("IDemoData") != null) {
                    this.demoItems = ((IDemoData)Activator.CreateInstance(value)).DemoItems;
                }
            }
        }
        public List<DemoItem> DemoItems => this.demoItems;

        public bool ShowItemUnderline { get; set; } = true;
        public DemoItemStatus DemoItemStatus { get; set; } = DemoItemStatus.None;

        public bool ShowBadge => DemoItemStatus != DemoItemStatus.None;

        public string BadgeIcon {
            get {
                return DemoItemStatus switch {
                    DemoItemStatus.Updated => "badgeupd",
                    DemoItemStatus.New => "badgenew",
                    _ => null,
                };
            }
        }
    }
}
