using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class SuperHeroTShirtViewModel : NotificationObject {
        string selectedSize;
        string selectedSuperhero;

        public IList<string> Sizes { get; }
        public IList<string> Superheroes { get; }
        public int SelectedColorIndex { get; set; }

        public string SelectedSize { get => this.selectedSize; set => SetProperty(ref this.selectedSize, value); }
        public string SelectedSuperhero { get => this.selectedSuperhero; set => SetProperty(ref this.selectedSuperhero, value); }

        public SuperHeroTShirtViewModel() {
            Sizes = new List<string>() { "S","M","L","XL","XXL","XXXL" };
            Superheroes = new List<string>() {
                "superhero_red",
                "superhero_orange",
                "superhero_yellow",
                "superhero_green",
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
    }
}
