using System;
using System.Collections.Generic;

namespace DemoCenter.Maui.Data {
    public class RangeAreaData {
        public List<List<RangeDateTimeData>> SeriesData { get; } = new List<List<RangeDateTimeData>> {
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 9, -2),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 11, -1),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 16, 3),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 21, 8),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 26, 13),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 29, 18),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 31, 21),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 29, 20),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 27, 16),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 22, 9),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 15, 4),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 10, 0),
            },
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 17, 6),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 19, 8),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 23, 11),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 26, 15),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 30, 20),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 33, 23),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 34, 24),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 35, 24),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 32, 21),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 28, 16),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 23, 11),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 18, 7),
            }
        };
    }
}
