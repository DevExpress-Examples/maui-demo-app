using System.Collections.Generic;
using DemoCenter.Maui.Data;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class DonutChartViewModel : ChartViewModelBase {
        BondPortfolioDiversification chartData = new BondPortfolioDiversification();

        public IList<PieData> SecuritiesByTypes => chartData.SecuritiesByTypes;
        public IList<PieData> SecuritiesByRisk => chartData.SecuritiesByRisk;

        public override string Title => "Bond Portfolio Diversification";
        public Color[] Palette => Palettes.Extended;
    }

    public class PieChartViewModel : ChartViewModelBase {
        SecuritesByRiskAndTypes chartData = new SecuritesByRiskAndTypes();

        public IList<PieData> Rating => chartData.Rating;
        public IList<PieData> Security => chartData.Security;

        public override string Title => "Securities by Type and Risk";
        public Color[] Palette => Palettes.Extended;
    }
}
