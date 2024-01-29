using System.Collections.Generic;
using System.ComponentModel;

namespace B_Validation_ByDataErrorInfo
{
  public class RegistrationVM : ObservableObject, IDataErrorInfo
  {
    #region Properties
    /// <summary>
    /// Error (not used).
    /// </summary>
    public string Error { get { return null; } }

    /// <summary>
    /// Error collection by, key, propertyName and, value, errorMessage.
    /// </summary>
    public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

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
        OnPropertyChanged(ref _username, value);
      }
    }

    /// <summary>
    /// Validator.
    /// </summary>
    /// <param name="name">Property name.</param>
    /// <returns>Error message.</returns>
    public string this[string name]
    {
      get
      {
        string result = null;

        switch (name)
        {
          case "Username":
            if (string.IsNullOrWhiteSpace(Username))
              result = "Username cannot be empty";
            else if (Username.Length < 5)
              result = "Username must be a minimum of 5 characters.";
            break;
        }

        // If ErrorCollection already contains an error for that key set it to the new result.
        // If it doesn't already contain an error for that key, add it to the collection.
        if (ErrorCollection.ContainsKey(name))
          ErrorCollection[name] = result;
        else if (result != null)
          ErrorCollection.Add(name, result);

        OnPropertyChanged("ErrorCollection");
        return result;
      }
    }
    #endregion
  }
}