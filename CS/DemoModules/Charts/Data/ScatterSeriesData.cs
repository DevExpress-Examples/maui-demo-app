using System;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.Data {
    public class ArchimedeanSpiralSeriesData : IXYSeriesData {
        const int PointsCount = 72;
        const double Step = 10.0;

        public int GetDataCount() => PointsCount;
        public SeriesDataType GetDataType() => SeriesDataType.Numeric;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public object GetKey(int index) => null;
        public double GetNumericArgument(int index) {
            double i = index * Step;
            double t = i / 180 * Math.PI;
            return t * Math.Cos(t);
        }
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetValue(DevExpress.Maui.Charts.ValueType valueType, int index) {
            double i = index * Step;
            double t = i / 180 * Math.PI;
            return t * Math.Sin(t);
        }
    }
}
