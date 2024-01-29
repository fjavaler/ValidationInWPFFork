﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace C_Validation_ByCustom
{
  /// <summary>
  /// A base for objects using property notification.
  /// </summary>
  public class ObservableObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Notify a property change.
    /// </summary>
    /// <param name="propertyName">Name of property to update</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Notify a property change that uses CallerMemberName attribute.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="backingField">Backing field of property</param>
    /// <param name="value">Value to give backing field</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>Success/Failure.</returns>
    protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
    {
      if (EqualityComparer<T>.Default.Equals(backingField, value))
        return false;

      backingField = value;
      OnPropertyChanged(propertyName);
      return true;
    }
  }
}
