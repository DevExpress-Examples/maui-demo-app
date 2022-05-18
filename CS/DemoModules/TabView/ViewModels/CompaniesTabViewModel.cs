using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class CompaniesTabViewModel : NavigationViewModelBase {
        readonly CompaniesData companies;
        CompanyData selectedItem;

        public CompaniesData CompaniesData => this.companies;

        public CompaniesTabViewModel() {
            this.companies = XmlDataDeserializer.GetData<CompaniesData>("Resources.CompaniesData.xml"); 
        }
        public CompanyData SelectedItem {
            get => this.selectedItem;
            set => SetProperty(ref this.selectedItem, value, onChanged: (oldValue, newValue) => {
                ResetSelectedItem(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        void ResetSelectedItem(CompanyData oldValue) {
            if(oldValue != null) {
                oldValue.IsSelected = false;
            } else {
                foreach(CompanyData curentItem in this.companies) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
    }
}
