using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class ColorViewModel {
        public static IList<ColorViewModel> CreateDefaultColors() {
            return new List<ColorViewModel>() {
                new ColorViewModel("Gray", Color.FromArgb("#f0f0f0")),
                new ColorViewModel("Red", Color.FromArgb("#ea4c4f")),
                new ColorViewModel("Orange", Color.FromArgb("#ff6b11")),
                new ColorViewModel("Yellow", Color.FromArgb("#fdaf18")),
                new ColorViewModel("Green", Color.FromArgb("#13b00c")),
                new ColorViewModel("Blue", Color.FromArgb("#2074ff")),
                new ColorViewModel("Purple", Color.FromArgb("#8c5aa3"))
            };
        }

        public Color Color { get; }
        public string Name { get; }

        public ColorViewModel() {
        }

        public ColorViewModel(string name, Color color) {
            Name = name;
            Color = color;
        }
    }
}
