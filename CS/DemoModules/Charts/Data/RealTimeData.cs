using System;
using System.ComponentModel;
using DevExpress.Maui.Charts;
using Microsoft.Maui.Devices.Sensors;

namespace DemoCenter.Maui.Data {
    public class RealTimeDataProvider {
        static readonly int MaxDataCount = 300;

        readonly IAccelerometer sensor;
        readonly ChartView chart;
        bool isRunning = false;

        public BindingList<DateTimeData> XAxisSeriesData { get; } = new BindingList<DateTimeData>();
        public BindingList<DateTimeData> YAxisSeriesData { get; } = new BindingList<DateTimeData>();
        public BindingList<DateTimeData> ZAxisSeriesData { get; } = new BindingList<DateTimeData>();

        public RealTimeDataProvider(ChartView chart) {
            this.chart = chart;
            sensor = Accelerometer.Default;
            sensor.ReadingChanged += Sensor_ReadingChanged;
        }

        private void Sensor_ReadingChanged(object sender, AccelerometerChangedEventArgs e) {
            chart.Dispatcher.Dispatch(() => {
                chart.SuspendRender();
                XAxisSeriesData.Add(new DateTimeData(DateTime.Now, e.Reading.Acceleration.X));
                RemoveExcessData(XAxisSeriesData);
                YAxisSeriesData.Add(new DateTimeData(DateTime.Now, e.Reading.Acceleration.Y));
                RemoveExcessData(YAxisSeriesData);
                ZAxisSeriesData.Add(new DateTimeData(DateTime.Now, e.Reading.Acceleration.Z));
                RemoveExcessData(ZAxisSeriesData);
                chart.ResumeRender();

            });
        }

        void RemoveExcessData(BindingList<DateTimeData> data) {
            if (data.Count > MaxDataCount)
                data.RemoveAt(0);
        }

        public void Stop() {
            sensor.Stop();
        }
        public void Start() {
            sensor.Start(SensorSpeed.Game);
        }
    }
}
