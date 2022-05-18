using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public abstract class ChartsPageViewModelBase : NotificationObject {
        ChartItemInfoContainerBase selectedItem;
        bool isVertical;
        public ChartItemInfoContainerBase SelectedItem {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, onChanged: (oldValue, newValue) => {
                ResetSelectedItem(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        public bool IsVertical {
            get => isVertical;
            set => SetVerticalState(value);
        }
        public void SetVerticalState(bool vertical) {
            isVertical = vertical;
            foreach(ChartItemInfoContainerBase curentItem in Content) {
                curentItem.IsVertical = vertical;
            }
        }
        public abstract List<ChartItemInfoContainerBase> Content { get; }
        void ResetSelectedItem(ChartItemInfoContainerBase oldSelectedItem) {
            if(oldSelectedItem != null) {
                oldSelectedItem.IsSelected = false;
            } else {
                foreach(ChartItemInfoContainerBase curentItem in Content) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
    }

}
