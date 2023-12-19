using System.Collections.Generic;
using DemoCenter.Maui.DemoModules.CollectionView.Data;

namespace DemoCenter.Maui.ViewModels {
    public class HorizontalScrollingModel : NotificationObject {
        readonly HouseSalesRepository repository = new HouseSalesRepository();
        public IList<House> ItemSource => this.repository.Houses;

        public HorizontalScrollingModel() {
        }
    }
}
