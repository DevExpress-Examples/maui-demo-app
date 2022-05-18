using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Editors.Views {
    public class CustomChipGroup : ChipGroup {
        public static readonly BindableProperty ChipIsRemoveIconVisibleProperty = BindableProperty.Create(nameof(ChipIsRemoveIconVisibleProperty), typeof(bool), typeof(CustomChipGroup), defaultValue: false, propertyChanged: ChipIsRemoveIconVisiblePropertyChanged);
        private static void ChipIsRemoveIconVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((CustomChipGroup)bindable).OnChipIsRemoveIconVisibleChanged((bool)newValue);
        }

        public CustomChipGroup() {
            ChipGeneration += OnChipGeneration;
        }

        private void OnChipGeneration(object sender, ChipGenerationEventArgs e) {
            e.Chip.IsCheckIconVisible = true;
        }

        public bool ChipIsRemoveIconVisible {
            get { return (bool)GetValue(ChipIsRemoveIconVisibleProperty); }
            set { SetValue(ChipIsRemoveIconVisibleProperty, value); }
        }

        private void OnChipIsRemoveIconVisibleChanged(bool newValue) {
            foreach (DevExpress.Maui.Editors.Chip dxChip in Chips) {
                dxChip.IsRemoveIconVisible = newValue;
            }
        }
    }
}
