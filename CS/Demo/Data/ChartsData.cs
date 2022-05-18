using System;
using System.Collections.Generic;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class ChartsData : IDemoData {
        readonly List<DemoItem> demoItems;

        public ChartsData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Bar",
                    ControlsPageTitle = "Bar Charts",
                    Description="Demonstrates Stacked and Side-by-Side Bar series chart views.",
                    Module = typeof(BarCharts),
                    Icon = "barcharts",
                },
                new DemoItem() {
                    Title = "Line",
                    ControlsPageTitle = "Line Charts",
                    Description="Demonstrates use of Simple, Scatter, and Step Line chart series views.",
                    Module = typeof(LineCharts),
                    Icon = "linecharts"
                },
                new DemoItem() {
                    Title = "Area",
                    ControlsPageTitle = "Area Charts",
                    Description="Demonstrates Simple, Stacked and Step Area chart series views.",
                    Module = typeof(AreaCharts),
                    Icon = "areacharts"
                },
                new DemoItem() {
                    Title = "Pie & Donut",
                    ControlsPageTitle = "Pie & Donut Charts",
                    Description="Demonstrates the use of multi-series Pie and Donut chart views.",
                    Module = typeof(PieCharts),
                    Icon = "piedonutcharts",
                    ShowItemUnderline = false
                },
                new DemoItem() {
                    Title = "Point & Bubble",
                    ControlsPageTitle = "Point & Bubble Charts",
                    Description="Demonstrates the use of Point and Bubble chart series views.",
                    Module = typeof(PointsCharts),
                    Icon = "pointbublecharts"
                },
                new DemoItem() {
                    Title = "Financial",
                    ControlsPageTitle = "Financial Chart",
                    Description="Displays Open-High-Low-Close stock price statistics as Candles Bars.",
                    Module = typeof(FinancialChart),
                    Icon = "financialcharts"
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title { get { return "ChartView"; } }
    }
}
