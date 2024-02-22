using System;
using System.Collections.Generic;

namespace DemoCenter.Maui.Views;

public class EqualizerMode {
    public EqualizerMode(byte id, string name, double f100, double f400, double f800, double f4k, double f10k) {
        ID = id;
        Name = name;
        F100 = f100;
        F400 = f400;
        F800 = f800;
        F4k = f4k;
        F10k = f10k;
    }
    public byte ID { get; set; }
    public string Name { get; set; }
    public double F100 { get; set; }
    public double F400 { get; set; }
    public double F800 { get; set; }
    public double F4k { get; set; }
    public double F10k { get; set; }
}

public partial class SlidersView : Demo.DemoPage {
    public SlidersView() {
        InitializeComponent();
        BindingContext = this;

        modes = new List<EqualizerMode>();
        modes.Add(new EqualizerMode(0, "Flat", 0, 0, 0, 0, 0));
        modes.Add(new EqualizerMode(1, "Classical", 5, 2, 0, 2, 5));
        modes.Add(new EqualizerMode(2, "Dance", 5, 0, 4, 5, 4));
        modes.Add(new EqualizerMode(5, "Bass", 7, 4, 0, 0, 0));
        modes.Add(new EqualizerMode(6, "Treble", 0, 0, 0, 4, 7));
        modes.Add(new EqualizerMode(9, "Manual", 0, 0, 0, 0, 0));
        modeComboBox.ItemsSource = modes;
        modeComboBox.DisplayMember = nameof(EqualizerMode.Name);
        modeComboBox.SelectedIndex = 0;
        modeComboBox.SelectionChanged += OnModeComboBoxSelectionChanged;

        sliderF100.ValueChanged += OnFrequencySliderValueChanged;
        sliderF400.ValueChanged += OnFrequencySliderValueChanged;
        sliderF800.ValueChanged += OnFrequencySliderValueChanged;
        sliderF4k.ValueChanged += OnFrequencySliderValueChanged;
        sliderF10k.ValueChanged += OnFrequencySliderValueChanged;
    }

    private List<EqualizerMode> modes;
    private bool isModeChanging;
    private void OnModeComboBoxSelectionChanged(object sender, EventArgs e) {
        isModeChanging = true;
        try {
            EqualizerMode manualMode = (EqualizerMode)modeComboBox.SelectedItem;
            sliderF100.Value = manualMode.F100;
            sliderF400.Value = manualMode.F400;
            sliderF800.Value = manualMode.F800;
            sliderF4k.Value = manualMode.F4k;
            sliderF10k.Value = manualMode.F10k;
        } finally {
            isModeChanging = false;
        }
    }
    private void OnFrequencySliderValueChanged(object sender, EventArgs e) {
        if (!isModeChanging) {
            EqualizerMode manualMode = modes[modes.Count - 1];
            manualMode.F100 = sliderF100.Value;
            manualMode.F400 = sliderF400.Value;
            manualMode.F800 = sliderF800.Value;
            manualMode.F4k = sliderF4k.Value;
            manualMode.F10k = sliderF10k.Value;
            modeComboBox.SelectedItem = manualMode;
        }
    }
}
