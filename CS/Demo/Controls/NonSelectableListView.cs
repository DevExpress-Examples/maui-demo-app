using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Demo {
    public class NonSelectableListView : ListView {

        public static readonly BindableProperty ScrollsToTopProperty = BindableProperty.Create(nameof(ScrollsToTop), typeof(bool), typeof(NonSelectableListView), defaultValue: true);

        public NonSelectableListView() : base(GetDefaultCachingStrategy()) {
        }
        public NonSelectableListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy) { }

        static ListViewCachingStrategy GetDefaultCachingStrategy() {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
                return ListViewCachingStrategy.RecycleElement;
            return ListViewCachingStrategy.RetainElement;
        }

        public bool ScrollsToTop {
            get => (bool)GetValue(ScrollsToTopProperty);
            set => SetValue(ScrollsToTopProperty, value);
        }

    }

    public class NonSelectableViewCell : ViewCell {
        public NonSelectableViewCell() {
        }
    }

    public class BouncelessCollectionView : CollectionView {

        public static readonly BindableProperty ScrollsToTopProperty = BindableProperty.Create(nameof(ScrollsToTop), typeof(bool), typeof(NonSelectableListView), defaultValue: true);

        public BouncelessCollectionView() : base() {
        }

        public bool ScrollsToTop {
            get => (bool)GetValue(ScrollsToTopProperty);
            set => SetValue(ScrollsToTopProperty, value);
        }

    }
}
