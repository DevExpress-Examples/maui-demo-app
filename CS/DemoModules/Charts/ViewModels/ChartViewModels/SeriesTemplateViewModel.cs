using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class SeriesTemplateViewModel : ChartViewModelBase {
        readonly CountryYearlyStatisticsData data = new CountryYearlyStatisticsData();

        public List<CountryGdpStatistics> SeriesData => this.data.SeriesData;

        string seriesDataMember;
        public string SeriesDataMember {
            get => this.seriesDataMember;
            set {
                if (this.seriesDataMember != value) {
                    this.seriesDataMember = value;
                    OnPropertyChanged("SeriesDataMember");
                }
            }
        }

        string argumentDataMember;
        public string ArgumentDataMember {
            get => this.argumentDataMember;
            set {
                if (this.argumentDataMember != value) {
                    this.argumentDataMember = value;
                    OnPropertyChanged("ArgumentDataMember");
                }
            }
        }

        public SeriesTemplateViewModel() {
            this.seriesDataMember = "Country";
            this.argumentDataMember = "Year";
        }
    }
}
