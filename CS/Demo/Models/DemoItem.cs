using System;
using System.Collections.Generic;
using System.ComponentModel;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.Models {
    public class DemoItem : INotifyPropertyChanged {
        string pageTitle;
        string icon;
        string controlsPageTitle;
        Type module;
        List<DemoItem> demoItems;

        public DemoItem() {
            this.demoItems = new List<DemoItem>();
        }

        public bool IconColorizationEnabled => Icon != "default_icon";
        public string Icon {
#if DEBUG
            get => String.IsNullOrEmpty(this.icon) ? "default_icon" : this.icon;
#else
            get => this.icon;
#endif
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
        public string BadgeText => DemoItemStatus switch {
            DemoItemStatus.Updated => "UPD",
            DemoItemStatus.New => "NEW",
            DemoItemStatus.None => string.Empty,
            _ => throw new ArgumentException($"Unknown {nameof(DemoItemStatus)}."),
        };

        public string BadgeIcon => DemoItemStatus switch {
            DemoItemStatus.Updated => "badgeupd",
            DemoItemStatus.New => "badgenew",
            _ => null,
        };

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
