using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoCenter.Maui.ViewModels {
    public class NotificationObject : INotifyPropertyChanged {
        protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName]string propertyName = "") {
            if(EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T backingStore, T value, Action<T,T> onChanged, [CallerMemberName]string propertyName = "") {
            if(EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            T oldValue = backingStore;
            backingStore = value;
            onChanged?.Invoke(oldValue, value);
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
