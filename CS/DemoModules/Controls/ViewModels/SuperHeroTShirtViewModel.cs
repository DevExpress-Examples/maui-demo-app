using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class SuperHeroTShirtViewModel : NotificationObject {
        string selectedSize;
        string selectedSuperhero;
        Rect imageRect;
        Rect detailsRect;

        public IList<string> Sizes { get; }
        public IList<string> Superheroes { get; }
        public int SelectedColorIndex { get; set; }
        public Rect ImageRect { get => this.imageRect; set => SetProperty(ref this.imageRect, value); }
        public Rect DetailsRect { get => this.detailsRect; set => SetProperty(ref this.detailsRect, value); }

        public string SelectedSize { get => this.selectedSize; set => SetProperty(ref this.selectedSize, value); }
        public string SelectedSuperhero { get => this.selectedSuperhero; set => SetProperty(ref this.selectedSuperhero, value); }

        public SuperHeroTShirtViewModel() {
            Sizes = new List<string>() { "S","M","L","XL","XXL","XXXL" };
            Superheroes = new List<string>() {
                "superhero_red",
                "superhero_orange",
                "superhero_yellow",
                "superhero_green",
                "superhero_lightblue",
                "superhero_blue",
                "superhero_purple"
            };
            SelectedColorIndex = 1;
            SelectedSize = Sizes[2];
            UpdateSuperhero();
        }

        public void UpdateSuperhero() {
            SelectedSuperhero = (SelectedColorIndex == -1) ? null : Superheroes[SelectedColorIndex];
        }

        public void UpdateLayout(bool isHorizontalOrientation) {
            if (isHorizontalOrientation) {
                ImageRect = new Rect(0, 0, 0.5, 1.0);
                DetailsRect = new Rect(1.0, 0.0, 0.5, 1.0);
            } else {
                ImageRect = new Rect(0, 0, 1.0, 0.5);
                DetailsRect = new Rect(0.0, 1.0, 1.0, 0.5);
            }
        }
    }
}
