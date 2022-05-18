using System;
using System.Collections.Generic;

namespace DemoCenter.Maui.Data {
    public class RangeDateTimeData {
        public DateTime Argument { get; private set; }
        public double Value1 { get; private set; }
        public double Value2 { get; private set; }

        public RangeDateTimeData(DateTime argument, double value1, double value2) {
            Argument = argument;
            Value1 = value1;
            Value2 = value2;
        }
    }

    public class RangeBarData {
        readonly List<List<RangeDateTimeData>> data = new List<List<RangeDateTimeData>> {
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 62.46, 53.23),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 66.91, 61.01),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 68.35, 63.71),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 74.94, 69.21),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 74.70, 67.98),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 67.52, 61.66),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 67.64, 60.70),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 62.90, 56.29),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 68.42, 57.93),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 62.06, 57.92),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 64.83, 60.17),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 69.70, 62.95),
            },
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 54.18, 46.31),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 57.21, 52.43),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 59.98, 55.76),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 66.24, 61.59),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 63.55, 53.49),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 59.18, 51.13),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 60.28, 55.08),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 57.05, 51.14),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 63.10, 53.91),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 56.52, 52.41),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 58.36, 54.93),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 61.30, 55.97),
            }
        };

        public List<List<RangeDateTimeData>> SeriesData => data;
    }

    public class SideBySideRangeBarData {
        readonly List<List<RangeDateTimeData>> data = new List<List<RangeDateTimeData>> {
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 55.26, 51.59),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 57.26, 52.72),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 60.14, 56.07),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 64.04, 61.94),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 62.82, 53.50),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 58.47, 52.51),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 60.21, 55.71),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 55.10, 54.17),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 58.09, 52.81),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 56.66, 53.82),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 58.11, 57.24),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 60.20, 59.20),
            },
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 1.43, 1.36),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 1.61, 1.45),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 1.92, 1.74),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 2.03, 1.96),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 1.91, 1.74),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 1.87, 1.67),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 1.93, 1.76),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 1.73, 1.62),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 1.75, 1.61),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 1.68, 1.65),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 1.65, 1.62),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 1.61, 1.57),
            }
        };

        public List<List<RangeDateTimeData>> SeriesData => data;
    }
}
