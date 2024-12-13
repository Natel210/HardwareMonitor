﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SimpleHardwareMonitor.viewmodel
{
    public partial class PsuVM : INotifyPropertyChanged
    {
        public static PsuVM instance = new PsuVM();
    }


    public partial class PsuVM : INotifyPropertyChanged
    {
        private readonly SynchronizationContext _syncContext;
        public event PropertyChangedEventHandler PropertyChanged;
        private PsuVM() { _syncContext = SynchronizationContext.Current; }
        private bool Set<T>(ref T field, T newValue = default(T), [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}