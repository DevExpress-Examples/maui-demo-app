using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DemoCenter.Maui.Data {
    [XmlRoot("DataSetsContainer")]
    public class DataSetsContainer<T> {
        [XmlArrayItem]
        public List<DataSetContainer<T>> DataSets { get; set; }
    }

    [XmlRoot("DataSetContainer")]
    public class DataSetContainer<T> {
        [XmlElement]
        public string Name { get; set; }
        [XmlArrayItem]
        public List<T> DataSet { get; set; }
    }

    [XmlRoot("NumericDataSets")]
    public class NumericDataSets : DataSetsContainer<NumericData> { }
    [XmlRoot("DateTimeDataSets")]
    public class DateTimeDataSets : DataSetsContainer<DateTimeData> { }
    [XmlRoot("QualitativeDataSets")]
    public class QualitativeDataSets : DataSetsContainer<QualitativeData> { }

    public class QualitativeData {
        public string Argument { get; set; }
        public double Value { get; set; }
        public QualitativeData() { }
        public QualitativeData(string argument, double value) {
            Argument = argument;
            Value = value;
        }
    }

    public class DateTimeData {
        public DateTime Argument { get; set; }
        public double Value { get; set; }
        public DateTimeData() { }
        public DateTimeData(DateTime argument, double value) {
            Argument = argument;
            Value = value;
        }
    }

    public class NumericData {
        public double Argument { get; private set; }
        public double Value { get; private set; }
        public NumericData(double argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
    
    public class PieData {
        public string Label { get; }
        public double Value { get; }
        
        public PieData(string label, double value) {
            Label = label;
            Value = value;
        }
    }
}
