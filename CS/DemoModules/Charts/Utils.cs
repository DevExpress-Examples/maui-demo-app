using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Maui.Graphics;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;
using DemoCenter.Maui.DemoModules.Grid.Data;
using System.Collections.Generic;

namespace DemoCenter.Maui {
    [JsonSerializable(typeof(InvocesObject))]
    [JsonSerializable(typeof(EmployeeTasksObject))]
    [JsonSerializable(typeof(QuotesObject))]
    [JsonSerializable(typeof(List<Employee>))]
    [JsonSerializable(typeof(DateTimeDataSets))]
    [JsonSerializable(typeof(QualitativeDataSets))]
    public partial class TrimmableContext : JsonSerializerContext { }

    static class XmlDataDeserializer {
        public static T GetData<T>(string resourceName) {
            T data;
            var assembly = typeof(T).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                XmlReader reader = XmlReader.Create(stream);
                var serializer = new XmlSerializer(typeof(T));
                data = (T)serializer.Deserialize(reader);
            }
            return data;
        }
    }
    static class JsonDataDeserializer {
        private static JsonSerializerOptions options = new JsonSerializerOptions() {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            TypeInfoResolver = TrimmableContext.Default,
        };
        public static T GetData<T>(string resourceName) {
            T data;
            System.Reflection.Assembly assembly = typeof(T).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                data = JsonSerializer.Deserialize<T>(new StreamReader(stream).ReadToEnd(), options);
            }
            return data;
        }
    }
    static class PaletteLoader {
        public static Color[] LoadPalette(params string[] values) {
            Color[] colors = new Color[values.Length];
            for (int i = 0; i < values.Length; i++)
                colors[i] = Color.FromArgb(values[i]);
            return colors;
        }
    }

    static class Palettes {
        static readonly Color[] extended = PaletteLoader.LoadPalette("#FF42A5F5", "#FFFF5252", "#FF4CAF50", "#FFFFAB40", "#FFBDBDBD",
                                                                     "#FF536DFE", "#FF009688", "#FFE91E63", "#FFFF6E40", "#FF9C27B0");

        public static Color[] Extended => extended;
    }

    sealed class AxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (((double)value) / 1000000.0).ToString() + "M";
    }

    sealed class BarChartAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (((double)value) / 1000000.0).ToString();
    }

    sealed class PopulationPyramidAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (Math.Abs((double)value) / 1000000.0).ToString() + "M";
    }

    sealed class CryptocurrencyPortfolioAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + "%";
    }

    sealed class FrequencyAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + " Hz";
    }

    sealed class PercentAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + " %";
    }

    sealed class PopulationByCountryTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) {
            double val = ((double)value) / 1e9;
            if (val == 0.0)
                return "0";
            return val.ToString() + "B";
        }
    }
}
