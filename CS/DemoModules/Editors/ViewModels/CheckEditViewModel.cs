﻿using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataForm;
using DevExpress.Maui.Editors;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class CheckEditViewModel : NotificationObject {
        TextAlignment labelVerticalAlignment = TextAlignment.Center;
        TextAlignment labelHorizontalAlignment = TextAlignment.Start;

        TextAlignment checkBoxAlignment = TextAlignment.Center;
        CheckBoxPosition checkBoxPosition = CheckBoxPosition.Start;

        CheckEditGlyphSet selectedGlyph;
        Color selectedColor;
        bool allowIndeterminateInput;
        bool allowCustomCheckedCheckBoxColor;

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public bool AllowIndeterminateInput {
            get => this.allowIndeterminateInput;
            set => SetProperty(ref this.allowIndeterminateInput, value);
        }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public bool AllowCustomCheckedCheckBoxColor {
            get => this.allowCustomCheckedCheckBoxColor;
            set => SetProperty(ref this.allowCustomCheckedCheckBoxColor, value, UpdateCheckedCheckBoxColor);
        }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public IList<CheckEditGlyphSet> AvailableGlyphs { get; }


        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public IList<ColorViewModel> AvailableCheckedColors { get; }

        public IList<TextAlignment> TextAlignments { get; }
        public IList<CheckBoxPosition> CheckBoxPositions { get; }


        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public CheckEditGlyphSet SelectedGlyph {
            get => this.selectedGlyph;
            set => SetProperty(ref this.selectedGlyph, value);
        }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public Color SelectedCheckedColor {
            get => this.selectedColor;
            set => SetProperty(ref this.selectedColor, value, UpdateCheckedCheckBoxColor);
        }

        [DataFormDisplayOptions(LabelText = "Label Vertical Alignment", GroupName = "Layout Options")]
        public TextAlignment LabelVerticalAlignment {
            get => this.labelVerticalAlignment;
            set => SetProperty(ref this.labelVerticalAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Label Horizontal Alignment", GroupName = "Layout Options")]
        public TextAlignment LabelHorizontalAlignment {
            get => this.labelHorizontalAlignment;
            set => SetProperty(ref this.labelHorizontalAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Checkbox Alignment", GroupName = "Layout Options")]
        public TextAlignment CheckBoxAlignment {
            get => this.checkBoxAlignment;
            set => SetProperty(ref this.checkBoxAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Checkbox Position", GroupName = "Layout Options")]
        public CheckBoxPosition CheckBoxPosition {
            get => this.checkBoxPosition;
            set => SetProperty(ref this.checkBoxPosition, value);
        }

        CheckEdit Edit { get; }
        Color DefaultCheckedCheckBoxColor { get; }

        public CheckEditViewModel(CheckEdit checkEdit) {
            Edit = checkEdit;
            DefaultCheckedCheckBoxColor = Edit.ActualAppearance.CheckedCheckBoxColor;
            AvailableGlyphs = new List<CheckEditGlyphSet> {
                new CheckEditGlyphSet() {
                    CheckedGlyph = null,
                    IndeterminateGlyph = null,
                    UncheckedGlyph = null,
                    LabelText = "Default Checkboxes"
                },
                new CheckEditGlyphSet() {
                    CheckedGlyph = ImageSource.FromFile("editorsicroundcheckboxchecked"),
                    IndeterminateGlyph = ImageSource.FromFile("editorsicroundcheckboxindeterminate"),
                    UncheckedGlyph = ImageSource.FromFile("editorsicroundcheckboxunchecked"),
                    LabelText = "Round Checkboxes"
                }
            };
            AvailableCheckedColors = ColorViewModel.CreateDefaultColors();
            TextAlignments = new List<TextAlignment>() { TextAlignment.Start, TextAlignment.Center, TextAlignment.End };
            CheckBoxPositions = new List<CheckBoxPosition>() {
                CheckBoxPosition.Start,
                CheckBoxPosition.Top,
                CheckBoxPosition.End,
                CheckBoxPosition.Bottom
            };

            this.selectedGlyph = AvailableGlyphs[0];
            this.selectedColor = AvailableCheckedColors.Single(it => it.Name == "Purple").Color;
            UpdateCheckedCheckBoxColor();
        }

        void UpdateCheckedCheckBoxColor() {
            Edit.CheckedCheckBoxColor = AllowCustomCheckedCheckBoxColor ? SelectedCheckedColor : DefaultCheckedCheckBoxColor;
        }
    }

    public class CheckEditGlyphSet {
        public string LabelText { get; set; }

        public ImageSource CheckedGlyph { get; set; }
        public ImageSource UncheckedGlyph { get; set; }
        public ImageSource IndeterminateGlyph { get; set; }
    }
}
