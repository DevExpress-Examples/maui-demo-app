using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json.Linq;

namespace DemoCenter.Maui.Data {
    public class OutsideVendorCostsData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> DevAVNorth => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DevAVSouth => seriesData.DataSets[1];

        public OutsideVendorCostsData() {
            seriesData = JsonDataDeserializer.GetData<DateTimeDataSets>("Resources.OutsideVendorCosts.json");
        }
    }
    
    public class PopulationStructureData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> MaleSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> FemaleSeriesData => seriesData.DataSets[1];

        public PopulationStructureData() {
            seriesData = JsonDataDeserializer.GetData<QualitativeDataSets>("Resources.PopulationStructure.json");
        }
    }
    
    public class AgeStructureData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> Male0to14and65SeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> Male15to64SeriesData => seriesData.DataSets[1];
        public DataSetContainer<QualitativeData> Female0to14and65SeriesData => seriesData.DataSets[2];
        public DataSetContainer<QualitativeData> Female15to64SeriesData => seriesData.DataSets[3];

        public AgeStructureData() {
            seriesData = JsonDataDeserializer.GetData<QualitativeDataSets>("Resources.AgeStructure.json");
        }
    }

    public class DevAVSalesMixByRegionData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> ProjectorsSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> TelevisionsSeriesData => seriesData.DataSets[1];

        public DevAVSalesMixByRegionData() {
            seriesData = JsonDataDeserializer.GetData<QualitativeDataSets>("Resources.DevAVSalesMixByRegion.json");
        }
    }

    public class PopulationPyramidData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> MaleSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> FemaleSeriesData => seriesData.DataSets[1];

        public PopulationPyramidData() {
            seriesData = JsonDataDeserializer.GetData<QualitativeDataSets>("Resources.PopulationPyramid.json");
        }
    }

    public class CryptocurrencyPortfolioData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> SymbolsData => seriesData.DataSets[0];

        public CryptocurrencyPortfolioData() {
            seriesData = JsonDataDeserializer.GetData<QualitativeDataSets>("Resources.CryptocurrencyPortfolio.json");
        }
    }

    public class AverageDieselPricesData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> DieselPrices => seriesData.DataSets[0];

        public AverageDieselPricesData() {
            seriesData = JsonDataDeserializer.GetData<DateTimeDataSets>("Resources.AverageDieselPrices.json");
        }

    }

    public class LondonWeatherData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> NightMin => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DayMax => seriesData.DataSets[1];
        public double NightMinAverageValue => GetAverageValue(NightMin);
        public double DayMaxAverageValue => GetAverageValue(DayMax);

        public LondonWeatherData() {
            seriesData = JsonDataDeserializer.GetData<DateTimeDataSets>("Resources.LondonWeather.json");
        }

        double GetAverageValue(DataSetContainer<DateTimeData> data) {
            double result = 0;
            foreach (DateTimeData res in data.DataSet)
                result += res.Value;
            return result / data.DataSet.Count;
        }
    }

    public class TrendPopulationData {
        readonly DateTimeDataSets populationDataSource;

        public DataSetContainer<DateTimeData> Europe => populationDataSource.DataSets[0];
        public DataSetContainer<DateTimeData> Americas => populationDataSource.DataSets[1];
        public DataSetContainer<DateTimeData> Africa => populationDataSource.DataSets[2];

        public TrendPopulationData() {
            this.populationDataSource = JsonDataDeserializer.GetData<DateTimeDataSets>("Resources.TrendPopulation.json");
        }
    }

    public class SalesByLastYearsData {
        readonly string[] names = { "North America", "Europe", "Australia" };
        readonly double[][] values = {
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 1.09, 2.01, 1.85, 1.78, 1.957, 2.272 }
        };
        readonly DataSetsContainer<DateTimeData> seriesData = new DataSetsContainer<DateTimeData>();

        public DataSetContainer<DateTimeData> NorthAmerica => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> Europe => seriesData.DataSets[1];
        public DataSetContainer<DateTimeData> Australia => seriesData.DataSets[2];

        public SalesByLastYearsData() {
            int year = DateTime.Now.Year;
            seriesData.DataSets = new List<DataSetContainer<DateTimeData>>();
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                var dataContainer = new DataSetContainer<DateTimeData>() { Name = names[i], DataSet = data };
                seriesData.DataSets.Add(dataContainer);
            }
        }
    }

    public class BranchesSalesData {
        readonly string[] names = { "DevAV East", "DevAV West", "DevAV South", "DevAV Center", "DevAV North" };
        readonly double[][] values = {
            new double[] { 0D, 0D, 0.003, 0.32, 0.51, 1.71 },
            new double[] { 0.95, 1.53, 1.75, 1.31, 1.31, 1.22 },
            new double[] { 1.09, 1.01, 1.11, 1.12, 1.12, 1.111 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 }
        };
        readonly DataSetsContainer<DateTimeData> seriesData = new DataSetsContainer<DateTimeData>();

        public DataSetContainer<DateTimeData> DevAVEast => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DevAVWest => seriesData.DataSets[1];
        public DataSetContainer<DateTimeData> DevAVSouth => seriesData.DataSets[2];
        public DataSetContainer<DateTimeData> DevAVCenter => seriesData.DataSets[3];
        public DataSetContainer<DateTimeData> DevAVNorth => seriesData.DataSets[4];

        public BranchesSalesData() {
            GenerateData();
        }
        void GenerateData() {
            int year = DateTime.Now.Year;
            seriesData.DataSets = new List<DataSetContainer<DateTimeData>>();
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                var dataContainer = new DataSetContainer<DateTimeData>() { Name = names[i], DataSet = data };
                seriesData.DataSets.Add(dataContainer);
            }
        }
    }

    public class SalesByYearsData {
        static DateTime StartDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-10);

        readonly IList<string> categories = new List<string> { "Asia", "Australia", "Europe", "N. America", "S. America" };
        readonly IList<IList<double>> values = new List<IList<double>> {
            new List<double> { 1.8532D, 1.9849D, 2.4372D, 2.5147D, 2.7514D, 2.8532D, 3.5849D, 4.2372D, 4.7685D, 5.2890D },
            new List<double> { 0.6988D, 0.8320D, 0.8711D, 0.9210D, 0.9651D, 1.2586D, 1.5744D, 1.7871D, 1.9576D, 2.2727D },
            new List<double> { 1.1210D, 1.1311D, 1.3025D, 1.3214D, 1.4284D, 1.9579D, 2.5664D, 3.0884D, 3.3579D, 3.7257D },
            new List<double> { 1.9855D, 2.1288D, 2.4855D, 2.7477D, 2.8825D, 2.9855D, 3.0788D, 3.4855D, 3.7477D, 4.1825D },
            new List<double> { 0.9127D, 0.9734D, 0.9927D, 1.1237D, 1.3172D, 1.3827D, 1.5734D, 1.6027D, 1.8237D, 2.1172D }
        };

        public IList<List<DateTimeData>> Data { get; private set; } = new List<List<DateTimeData>>();
        public IList<PieData> PieData { get; private set; } = new List<PieData>();

        public SalesByYearsData() {
            for (int j = 0; j < values.Count; j++) {
                List<DateTimeData> seriesData = new List<DateTimeData>();
                StartDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-10);
                for (int i = 0; i < values[j].Count; i++)
                    seriesData.Add(new DateTimeData(StartDate.AddYears(i), values[j][i]));
                Data.Add(seriesData);
                PieData.Add(new PieData(categories[j], values[j].Sum()));
            }
        }
    }

    public class BondPortfolioDiversification {
        public IList<PieData> SecuritiesByTypes = new List<PieData>();
        public IList<PieData> SecuritiesByRisk = new List<PieData>();

        public BondPortfolioDiversification() {
            SecuritiesByTypes.Add(new PieData("Stock",417360.00));
            SecuritiesByTypes.Add(new PieData("Mutual Fund", 27414.32));
            SecuritiesByTypes.Add(new PieData("Bond", 35682.00));

            SecuritiesByRisk.Add(new PieData("Income", 132826.00));
            SecuritiesByRisk.Add(new PieData("Growth", 208816.0));
            SecuritiesByRisk.Add(new PieData("Speculation", 24700.00));
            SecuritiesByRisk.Add(new PieData("Hedge", 80114.00));
        }
    }

    public class SecuritesByRiskAndTypes {
        public IList<PieData> Rating { get; } = new List<PieData>();
        public IList<PieData> Security { get; } = new List<PieData>();

        public SecuritesByRiskAndTypes() {
            Rating.Add(new PieData("AA", 13));
            Rating.Add(new PieData("MBB+", 7));
            Rating.Add(new PieData("BBB", 45));
            Rating.Add(new PieData("BBB-", 20));
            Rating.Add(new PieData("NR", 15));

            Security.Add(new PieData("FRN", 16.0));
            Security.Add(new PieData("FCB", 41.0));
            Security.Add(new PieData("CIB", 25.0));
            Security.Add(new PieData("IAB", 18.0));
        }
    }

    public class TunedEngineData {
        public IList<NumericData> NEPower = new List<NumericData>();
        public IList<NumericData> NETorque = new List<NumericData>();
        public IList<NumericData> MKRPower = new List<NumericData>();
        public IList<NumericData> MKRTorque = new List<NumericData>();
        public IList<NumericData> NEFuelRate = new List<NumericData>();
        public IList<NumericData> MKRFuelRate = new List<NumericData>();

        public TunedEngineData() {
            NEPower = new List<NumericData>() {
                new NumericData(1000, 100),
                new NumericData(1500, 105),
                new NumericData(2100, 125),
                new NumericData(2500, 145),
                new NumericData(3200, 225),
                new NumericData(3800, 250),
                new NumericData(4500, 220),
                new NumericData(5300, 190),
                new NumericData(6100, 180),
                new NumericData(7000, 175)};

            NETorque = new List<NumericData>() {
                new NumericData(1000, 180),
                new NumericData(1500, 200),
                new NumericData(2100, 240),
                new NumericData(2500, 260),
                new NumericData(3200, 270),
                new NumericData(3800, 290),
                new NumericData(4500, 300),
                new NumericData(5300, 330),
                new NumericData(6100, 360),
                new NumericData(7000, 370)};

            MKRPower = new List<NumericData>() {
                new NumericData(1000, 80),
                new NumericData(1500, 85),
                new NumericData(2100, 100),
                new NumericData(2500, 115),
                new NumericData(3200, 205),
                new NumericData(3800, 230),
                new NumericData(4500, 200),
                new NumericData(5300, 160),
                new NumericData(6100, 155),
                new NumericData(7000, 145)};

            MKRTorque = new List<NumericData>() {
                new NumericData(1000, 160),
                new NumericData(1500, 180),
                new NumericData(2100, 220),
                new NumericData(2500, 245),
                new NumericData(3200, 255),
                new NumericData(3800, 270),
                new NumericData(4500, 280),
                new NumericData(5300, 310),
                new NumericData(6100, 340),
                new NumericData(7000, 350)};

            NEFuelRate = new List<NumericData>() {
                new NumericData(1000, 18.1),
                new NumericData(1500, 19.6),
                new NumericData(2100, 23.5),
                new NumericData(2500, 26.1),
                new NumericData(3200, 29.4),
                new NumericData(3800, 31.4),
                new NumericData(4500, 27.7),
                new NumericData(5300, 19.6),
                new NumericData(6100, 16.8),
                new NumericData(7000, 15.5)};

            MKRFuelRate = new List<NumericData>() {
                new NumericData(1000, 21.4),
                new NumericData(1500, 23.5),
                new NumericData(2100, 29.4),
                new NumericData(2500, 33.6),
                new NumericData(3200, 36.2),
                new NumericData(3800, 39.2),
                new NumericData(4500, 33.6),
                new NumericData(5300, 26.1),
                new NumericData(6100, 21.4),
                new NumericData(7000, 18.1)};
        }
    }

    public class SplineData {
        public IList<DateTimeData> SeriesData = new List<DateTimeData>();

        public SplineData() {
            SeriesData = new List<DateTimeData>() {
                new DateTimeData(new DateTime(1999, 1, 15), 0),
                new DateTimeData(new DateTime(1999, 2, 1), 20 * 10e11),
                new DateTimeData(new DateTime(1999, 2, 15), 200 * 10e11),
                new DateTimeData(new DateTime(1999, 3, 1), 220 * 10e11),
                new DateTimeData(new DateTime(1999, 3, 15), 160 * 10e11),
                new DateTimeData(new DateTime(1999, 4, 1), 290 * 10e11),
                new DateTimeData(new DateTime(1999, 4, 15), 80 * 10e11),
                new DateTimeData(new DateTime(1999, 5, 1), 60 * 10e11),
                new DateTimeData(new DateTime(1999, 5, 15), 0),
                new DateTimeData(new DateTime(1999, 6, 1), 80 * 10e11),
                new DateTimeData(new DateTime(1999, 6, 15), 20 * 10e11),
                new DateTimeData(new DateTime(1999, 7, 1), 260 * 10e11),
                new DateTimeData(new DateTime(1999, 7, 15), 20 * 10e11),
                new DateTimeData(new DateTime(1999, 8, 1), 10 * 10e11),
                new DateTimeData(new DateTime(1999, 8, 15), 30 * 10e11),
                new DateTimeData(new DateTime(1999, 9, 1), 0)};
        }
    }

    public class HeadphonesData {
        public IList<NumericData> FirstHeadphones90 = new List<NumericData>();
        public IList<NumericData> FirstHeadphones100 = new List<NumericData>();
        public IList<NumericData> SecondHeadphones90 = new List<NumericData>();
        public IList<NumericData> SecondHeadphones100 = new List<NumericData>();

        public HeadphonesData() {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.HeadphoneComparison.dat")) {
                StreamReader reader = new StreamReader(stream);
                string data = reader.ReadToEnd();
                String[] dataItems = data.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < dataItems.Length; i++) {
                    String[] row = dataItems[i].Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]
                        .Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    double frequency = Convert.ToDouble(row[1], CultureInfo.InvariantCulture);
                    double thd90 = Convert.ToDouble(row[2], CultureInfo.InvariantCulture);
                    double thd100 = Convert.ToDouble(row[3], CultureInfo.InvariantCulture);
                    int headphoneNumber = Convert.ToInt32(row[0], CultureInfo.InvariantCulture);
                    if (headphoneNumber == 1) {
                        FirstHeadphones90.Add(new NumericData(frequency, thd90));
                        FirstHeadphones100.Add(new NumericData(frequency, thd100));
                    } else if (headphoneNumber == 2) {
                        SecondHeadphones90.Add(new NumericData(frequency, thd90));
                        SecondHeadphones100.Add(new NumericData(frequency, thd100));
                    }
                }
            }
        }
    }

    public class TemperaturePoint {
        public double Temperature { get; private set; }
        public DateTime Time { get; private set; }

        public TemperaturePoint(DateTime time, double temperature) {
            Temperature = temperature;
            Time = time;
        }
    }

    public class TemperatureData {
        const int PointsCount = 250;

        List<TemperaturePoint> data = new List<TemperaturePoint>(PointsCount);

        internal double OptimalTemperature {
            get { return 53; }
        }
        internal List<TemperaturePoint> SeriesData {
            get { return data; }
        }

        internal TemperatureData() {
            Random random = new Random(9);
            DateTime date = new DateTime(2010, 1, 1, 0, 0, 0);
            double preTemperature = 50;
            for (int i = 0; i < PointsCount; i++) {
                TimeSpan time = TimeSpan.FromSeconds(i);
                double temperature = preTemperature + (random.NextDouble() - 0.5) * 10;
                if (temperature > 90)
                    temperature -= 20;
                if (temperature < 20)
                    temperature += 10;
                TemperaturePoint temperaturePoint = new TemperaturePoint(date + time, temperature);
                data.Add(temperaturePoint);
                preTemperature = temperature;
            }
        }
    }

    public class LightSpectorData {
        public IList<NumericData> LightSpectors { get; }


        public LightSpectorData() {
            LightSpectors = new List<NumericData>();
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.LightSpector.dat")) {
                StreamReader reader = new StreamReader(stream);
                string data = reader.ReadToEnd();
                String[] dataItems = data.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < dataItems.Length; i++) {
                    String[] row = dataItems[i].Split(new String[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                    double argument = Convert.ToDouble(row[0], CultureInfo.InvariantCulture);
                    double value = Convert.ToDouble(row[1], CultureInfo.InvariantCulture);
                    LightSpectors.Add(new NumericData(argument, value));
                }
            }
        }
    }

    public class LightSpectorColorizer : ICustomPointColorizer, ILegendItemProvider {
        Color waveLengthToColor(double waveLength) {
            double gamma = 0.8;
            double red = 0.0;
            double green = 0.0;
            double blue = 0.0;
            if (waveLength <= 440) {
                double attenuation = 0.3 + 0.7 * (waveLength - 380) / (440 - 380);
                red = Math.Pow((-(waveLength - 440) / (440 - 380)) * attenuation, gamma);
                green = 0.0;
                blue = Math.Pow(1.0 * attenuation, gamma);
            } else if (waveLength <= 490) {
                red = 0.0;
                green = Math.Pow((waveLength - 440) / (490 - 440), gamma);
                blue = 1.0;
            } else if (waveLength <= 510) {
                red = 0.0;
                green = 1.0;
                blue = Math.Pow(-(waveLength - 510) / (510 - 490), gamma);
            } else if (waveLength <= 580) {
                red = Math.Pow((waveLength - 510) / (580 - 510), gamma);
                green = 1.0;
                blue = 0.0;
            } else if (waveLength <= 645) {
                red = 1.0;
                green = Math.Pow(-(waveLength - 645) / (645 - 580), gamma);
                blue = 0.0;
            } else if (waveLength <= 750) {
                double attenuation = 0.3 + 0.7 * (750 - waveLength) / (750 - 645);
                red = Math.Pow(1.0 * attenuation, gamma);
                green = 0.0;
                blue = 0.0;
            }
            return Color.FromRgb(red, green, blue);
        }

        protected virtual double[] GetWavesForLegend() {
            return new double[0];
        }

        Color ICustomPointColorizer.GetColor(ColoredPointInfo info) {
            return waveLengthToColor(info.NumericArgument);
        }
        ILegendItemProvider ICustomPointColorizer.GetLegendItemProvider() {
            return this;
        }

        CustomLegendItem ILegendItemProvider.GetLegendItem(int index) {
            double waveLength = GetWavesForLegend()[index];
            Color color = waveLengthToColor(waveLength);
            return new CustomLegendItem($"{waveLength} nm", color);
        }
        int ILegendItemProvider.GetLegendItemCount() {
            return GetWavesForLegend().Length;
        }
    }

    public class LightSpectorColorizerWithCustomLegend : LightSpectorColorizer {
        protected override double[] GetWavesForLegend() {
            return new double[] { 400, 440, 480, 540, 580, 610, 650 };
        }
    }

    public class PopulationByCountryData {
        public List<QualitativeData> SeriesData { get; }

        public PopulationByCountryData() {
            SeriesData = new List<QualitativeData>() {
                new QualitativeData("China", 1382500000),
                new QualitativeData("India", 1314300000),
                new QualitativeData("United States", 324789000),
                new QualitativeData("Indonesia", 261600000),
                new QualitativeData("Brazil", 207332000),
                new QualitativeData("Pakistan", 196865000),
                new QualitativeData("Nigeria", 188500000),
                new QualitativeData("Bangladesh", 162240000),
                new QualitativeData("Russia", 146400000),
                new QualitativeData("Japan", 126760000),
                new QualitativeData("Mexico", 122273000),
                new QualitativeData("Ethiopia", 104345000),
                new QualitativeData("Philippines", 103906000),
                new QualitativeData("Egypt", 92847800)
            };
        }
    }
}
