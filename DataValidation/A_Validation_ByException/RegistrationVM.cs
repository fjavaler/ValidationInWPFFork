using System;

namespace A_Validation_ByException
{
  public class RegistrationVM : ObservableObject
  {
    /// <summary>
    /// Username backing field.
    /// </summary>
    private string _username;

    /// <summary>
    /// Username property.
    /// </summary>
    public string Username
    {
      get { return _username; }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
          throw new ArgumentException("Username cannot be empty.");

        OnPropertyChanged(ref _username, value);
      }
    }
  }
}
