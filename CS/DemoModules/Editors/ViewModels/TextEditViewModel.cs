using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class TextEditViewModel : NotificationObject {
        public const double DefaultCornerRadius = 4.0;
        const string DefaultHelpText = "Help Text";
        const string DefaultErrorText = "Error Message";
        const int DefaultMaxCharacterCount = 20;
        const CharacterCasing DefaultCharacterCasing = CharacterCasing.Normal;

        BoxMode selectedBoxMode;
        CornerMode selectedCornerMode;
        ColorViewModel selectedAccentColor;
        CharacterCasing selectedCharacterCasing;

        double topLeftCornerRadius;
        double topRightCornerRadius;
        double bottomLeftCornerRadius;
        double bottomRightCornerRadius;
        Microsoft.Maui.CornerRadius cornerRadius;

        string actualHelpText;
        int actualMaxCharacterCount;
        string actualErrorText;
        bool actualHasError;

        bool showStartIcon;
        bool showHelpText;
        bool showCharacterCounter;

        public IList<ColorViewModel> Colors { get; }

        public BoxMode SelectedBoxMode
        {
            get => selectedBoxMode;
            set => SetProperty(ref selectedBoxMode, value, () => {
                OnPropertyChanged(nameof(CanSetBottomCorners));
            });
        }

        public CharacterCasing SelectedCharacterCasing {
            get => selectedCharacterCasing;
            set => SetProperty(ref selectedCharacterCasing, value);
        }

        public CornerMode SelectedCornerMode { get => selectedCornerMode; set => SetProperty(ref selectedCornerMode, value); }
        public ColorViewModel SelectedAccentColor { get => selectedAccentColor; set => SetProperty(ref selectedAccentColor, value); }

        public string ActualHelpText { get => actualHelpText; private set => SetProperty(ref actualHelpText, value); }
        public int ActualMaxCharacterCount { get => actualMaxCharacterCount; private set => SetProperty(ref actualMaxCharacterCount, value); }
        public string ActualErrorText { get => actualErrorText; private set => SetProperty(ref actualErrorText, value); }
        public bool ActualHasError { get => actualHasError; private set => SetProperty(ref actualHasError, value); }

        public double TopLeftCornerRadius { get => topLeftCornerRadius; set => SetProperty(ref topLeftCornerRadius, value, UpdateCornerRadius); }
        public double TopRightCornerRadius { get => topRightCornerRadius; set => SetProperty(ref topRightCornerRadius, value, UpdateCornerRadius); }
        public double BottomLeftCornerRadius { get => bottomLeftCornerRadius; set => SetProperty(ref bottomLeftCornerRadius, value, UpdateCornerRadius); }
        public double BottomRightCornerRadius { get => bottomRightCornerRadius; set => SetProperty(ref bottomRightCornerRadius, value, UpdateCornerRadius); }
        public Microsoft.Maui.CornerRadius CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value); }
        public bool CanSetBottomCorners { get => SelectedBoxMode == BoxMode.Outlined; }

        public bool ShowStartIcon { get => showStartIcon; set => SetProperty(ref showStartIcon, value); }
        public bool ShowHelpText {
            get => showHelpText;
            set => SetProperty(ref showHelpText, value, () => {
                ActualHelpText = showHelpText ? DefaultHelpText : null;
            });
        }
        public bool ShowCharacterCounter {
            get => showCharacterCounter;
            set => SetProperty(ref showCharacterCounter, value, () => {
                ActualMaxCharacterCount = showCharacterCounter ? DefaultMaxCharacterCount : 0;
            });
        }

        public IList<BoxMode> BoxModes { get; }
        public IList<CornerMode> CornerModes { get; }
        public IList<CharacterCasing> CasingModes { get; }

        public ICommand ResetToDefaultCommand { get; }
        public ICommand ToggleErrorCommand { get; }

        public TextEditViewModel() {
            Colors = ColorViewModel.CreateDefaultColors();

            BoxModes = new List<BoxMode> {
                BoxMode.Outlined,
                BoxMode.Filled
            };
            CornerModes = new List<CornerMode> {
                CornerMode.Round,
                CornerMode.Cut
            };
            CasingModes = new List<CharacterCasing> {
                CharacterCasing.Normal,
                CharacterCasing.Upper,
                CharacterCasing.Lower
            };

            ResetToDefaultCommand = new DelegateCommand(ResetToDefault);
            ToggleErrorCommand = new DelegateCommand(ToggleError);

            ResetToDefault();
        }

        public virtual void ResetToDefault() {
            SelectedBoxMode = BoxModes[0];
            SelectedCornerMode = CornerModes[0];
            SelectedAccentColor = Colors[6];
            TopLeftCornerRadius = DefaultCornerRadius;
            TopRightCornerRadius = DefaultCornerRadius;
            BottomLeftCornerRadius = DefaultCornerRadius;
            BottomRightCornerRadius = DefaultCornerRadius;
            SelectedCharacterCasing = DefaultCharacterCasing;

            ShowStartIcon = false;
            ShowHelpText = true;
            ShowCharacterCounter = true;

            SetError(false);
        }

        public void ToggleError() => SetError(!ActualHasError);

        public void SetError(bool hasError) {
            ActualErrorText = hasError ? DefaultErrorText : null;
            ActualHasError = hasError;
        }

        void UpdateCornerRadius() {
            CornerRadius = new Microsoft.Maui.CornerRadius(TopLeftCornerRadius, TopRightCornerRadius, BottomLeftCornerRadius, BottomRightCornerRadius);
        }
    }
}
