using System.Collections;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using DevExpress.Maui.DataForm;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class CheckEditView : ContentPage {
        static readonly RowDefinitionCollection PortraitRowDefinitions = new RowDefinitionCollection {
            new RowDefinition {
                Height = new GridLength(200)
            },
            new RowDefinition {
                Height = new GridLength(1)
            },
            new RowDefinition {
                Height = GridLength.Star
            }
        };
        static readonly ColumnDefinitionCollection PortraitColumnDefinitions = new ColumnDefinitionCollection {
            new ColumnDefinition {
                Width = GridLength.Star
            }
        };


        static readonly RowDefinitionCollection LandscapeRowDefinitions = new RowDefinitionCollection {
            new RowDefinition {
                Height = GridLength.Star
            }
        };
        static readonly ColumnDefinitionCollection LandscapeColumnDefinitions = new ColumnDefinitionCollection() {
            new ColumnDefinition {
                Width = GridLength.Star
            },
            new ColumnDefinition {
                Width = new GridLength(1)
            },
            new ColumnDefinition {
                Width = GridLength.Star
            }
        };

        bool isChangingLayout = false;

        public CheckEditView() {
            InitializeComponent();
            this.settingsDataForm.PickerSourceProvider = new CheckBoxDemoPickerSourceProvider(BindingContext as CheckEditViewModel);

            if(DeviceInfo.Platform == DevicePlatform.iOS) {
                this.allowIndeterminateItem.SetDynamicResource(DataFormSwitchItem.OnColorProperty, "AccentColor");
            }

            if(DeviceInfo.Platform == DevicePlatform.Android) {
                this.allowIndeterminateItem.SetDynamicResource(DataFormSwitchItem.ThumbColorProperty, "AccentColor");
            }
        }

        protected override void OnSizeAllocated(double width, double height) {
            if (this.isChangingLayout)
                return;
            this.isChangingLayout = true;
            base.OnSizeAllocated(width, height);

            ChangeLayout(width > height);
            this.isChangingLayout = false;
        }

        void ChangeLayout(bool isLandscape) {
            if (isLandscape) {
                this.container.RowDefinitions = LandscapeRowDefinitions;
                this.container.ColumnDefinitions = LandscapeColumnDefinitions;

                Grid.SetColumn(this.edit, 0);
                Grid.SetRow(this.edit, 0);

                this.container.Remove(this.separator);
                this.container.Add(this.separator, 1, 0);

                this.container.Remove(this.settingsDataForm);
                this.container.Add(this.settingsDataForm, 2, 0);
            } else {
                this.container.RowDefinitions = PortraitRowDefinitions;
                this.container.ColumnDefinitions = PortraitColumnDefinitions;

                Grid.SetColumn(this.edit, 0);
                Grid.SetRow(this.edit, 0);

                this.container.Remove(this.separator);
                this.container.Add(this.separator, 0, 1);

                this.container.Remove(this.settingsDataForm);
                this.container.Add(this.settingsDataForm, 0, 2);
            }
        }
    }

    class CheckBoxDemoPickerSourceProvider : DevExpress.Maui.DataForm.IPickerSourceProvider {
        CheckEditViewModel vm;
        public CheckBoxDemoPickerSourceProvider(CheckEditViewModel vm) {
            this.vm = vm;
        }

        public IEnumerable GetSource(string propertyName) {
            switch (propertyName) {
                case "SelectedGlyph":
                    return this.vm.AvailableGlyphs;
                case "SelectedCheckedColor":
                    return this.vm.AvailableCheckedColors;
                default:
                    return null;
            }
        }
    }
}