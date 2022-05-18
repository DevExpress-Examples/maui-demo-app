using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class MultipleAxesViewModel : ChartViewModelBase {
        readonly TunedEngineData engineData;
        readonly Color[] palette = PaletteLoader.LoadPalette("#FF327bb7", "#FFe33e3e", "#FF81c1f6", "#FFff9090", "#FFff6363", "#FF42a5f6", "#4CA184AD", "#4C42a5f6", "#00000000");
        readonly IList<String> names;

        public IList<NumericData> NEPower => engineData.NEPower;
        public IList<NumericData> NETorque => engineData.NETorque;
        public IList<NumericData> MKRPower => engineData.MKRPower;
        public IList<NumericData> MKRTorque => engineData.MKRTorque;
        public IList<NumericData> NEFuelRate => engineData.NEFuelRate;
        public IList<NumericData> MKRFuelRate => engineData.MKRFuelRate;
        public IList<String> Names => names;
        public Color[] Palette => palette;

        public MultipleAxesViewModel() {
            engineData = new TunedEngineData();
            names = new List<String>() { "NEPower", "NETorque", "NEFuelRate", "MKRPower", "MKRTorque", "MKRFuelRate" };
        }
    }
}
