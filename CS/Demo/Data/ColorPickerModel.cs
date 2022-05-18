using System;
using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Editors;
using DevExpress.Utils;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Demo.Data {
    public class ColorPickerModel : NotificationObject {
        static IList<LabelModel> CreateLabelModels() {
            List<LabelModel> result = new List<LabelModel>();
            result.Add(new LabelModel() { Color = DXColor.White, TextColor = DXColor.Black, Id = 0 });
            result.Add(new LabelModel() { Color = DXColor.Red, Id = 1 });
            result.Add(new LabelModel() { Color = Color.FromArgb("#ffffa500"), Id = 2 }); // Orange
            result.Add(new LabelModel() { Color = DXColor.Yellow, Id = 3 });
            result.Add(new LabelModel() { Color = DXColor.Green, Id = 4 });
            result.Add(new LabelModel() { Color = DXColor.AliceBlue, Id = 5 });
            result.Add(new LabelModel() { Color = DXColor.Blue, Id = 6 });
            result.Add(new LabelModel() { Color = DXColor.Magenta, Id = 7 });
            return result;
        }

        Color color = DXColor.Default;
        LabelModel selectedItem;
        String title = "Select color";

        IList<LabelModel> labelModels = CreateLabelModels();

        public IList<LabelModel> LabelModels {
            get => this.labelModels;
            set {
                this.labelModels = value;
                OnPropertyChanged(nameof(LabelModels));
            }
        }

        public Color Color {
            get { return this.color; }
            set {
                if (Color == value)
                    return;

                this.color = value;
                ApplySelectedColor(value);
                OnPropertyChanged(nameof(Color));
            }
        }
        public LabelModel SelectedItem {
            get => this.selectedItem;
            set {
                Color = value.Color;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public String Title {
            get { return this.title; }
            set {
                if (this.title == value)
                    return;

                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        void ApplySelectedColor(Color selectedColor) {
            foreach (LabelModel colorModel in this.labelModels) {
                if (colorModel.Color == selectedColor) {
                    this.selectedItem = colorModel;
                    return;
                }
            }
            this.selectedItem = new LabelModel() { Color = selectedColor, Id = this.labelModels.Count };
            this.labelModels.Add(this.selectedItem);
        }
    }
}
