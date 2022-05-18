using System;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class SuperHeroTShirtView : ContentPage {
        const int animationDuration = 600;

        SuperHeroTShirtViewModel VM { get; } 

        public SuperHeroTShirtView() {
            InitializeComponent();
            BindingContext = VM = new SuperHeroTShirtViewModel();
            colorChoiceChipGroup.SelectionChanged += OnColorChanged;
        }

        async void OnColorChanged(object sender, EventArgs e) {
            superhero.TranslationX = 0;
            superhero.CancelAnimations();
            double translationX = superhero.Width;
            await Task.WhenAll(
                superhero.FadeTo(0, animationDuration, Easing.Linear),
                superhero.TranslateTo(translationX, superhero.Y, animationDuration, Easing.CubicInOut)
                );

            VM.UpdateSuperhero();
            superhero.TranslationX = -translationX;

            await Task.WhenAll(
                superhero.FadeTo(1, animationDuration, Easing.Linear),
                superhero.TranslateTo(0, superhero.Y, animationDuration, Easing.CubicInOut)
                );
        }
    }
}
