using System;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.Data {
    public class LargeDatasetSeriesData : IXYSeriesData {
        int dataCount;
        double lastPointValue = 0;
        double delta;
        Random random;

        public LargeDatasetSeriesData(int dataCount) {
            this.dataCount = dataCount;
            this.random = new Random(DateTime.Now.Millisecond * dataCount);
            this.delta = (random.NextDouble() - 0.5) / 100;
        }

        public int GetDataCount() => dataCount;
        public SeriesDataType GetDataType() => SeriesDataType.Numeric;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public double GetValue(DevExpress.Maui.Charts.ValueType valueType, int index) {
            return lastPointValue = lastPointValue + random.NextDouble() - 0.5 + delta;
        }
        public double GetNumericArgument(int index) { return index; }
        public string GetQualitativeArgument(int index) { return string.Empty; }
        public object GetKey(int index) => string.Empty;
    }
}
