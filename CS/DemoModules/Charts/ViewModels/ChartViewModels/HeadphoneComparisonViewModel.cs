using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class HeadphoneComparisonViewModel : ChartViewModelBase {
        readonly HeadphonesData headphonesData;
        readonly Color[] palette = PaletteLoader.LoadPalette("#317cb9", "#75b8ef", "#f14848", "#fe908f");
        readonly IList<String> names;

        public IList<NumericData> FirstHeadphones90 => headphonesData.FirstHeadphones90;
        public IList<NumericData> FirstHeadphones100 => headphonesData.FirstHeadphones100;
        public IList<NumericData> SecondHeadphones90 => headphonesData.SecondHeadphones90;
        public IList<NumericData> SecondHeadphones100 => headphonesData.SecondHeadphones100;
        public IList<String> Names => names;
        public Color[] Palette => palette;

        public HeadphoneComparisonViewModel() {
            headphonesData = new HeadphonesData();
            names = new List<String>() {
                "Headphones 1 90 dB SPL",
                "Headphones 1 100 dB SPL",
                "Headphones 2 90 dB SPL",
                "Headphones 2 100 dB SPL" };
        }
    }
}
