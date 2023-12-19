using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DemoCenter.Maui.Data {
    [XmlRoot(ElementName = "StockPrices")]
    public class StockPrices : List<StockPrice> { }

    public class StockPrice {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }

    public class StockData {
        public static StockPrices GetStockPrices() {
            StockPrices stockPrices;
            System.Reflection.Assembly assembly = typeof(StockData).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("Resources.GoogleStock.xml")) {
                XmlReader reader = XmlReader.Create(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(StockPrices));
                stockPrices = (StockPrices)serializer.Deserialize(reader);
            }
            return stockPrices;
        }
    }
}
