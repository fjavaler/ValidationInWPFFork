using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Validation_ByAnnotations
{
  public class RegistrationVM : ObservableObject
  {
    /// <summary>
    /// Username backing field.
    /// </summary>
    private string _username;

    /// <summary>
    /// Username property with validation attributes.
    /// </summary>
    [Required(ErrorMessage = "Must not be empty.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
    public string Username
    {
      get { return _username; }
      set
      {
        ValidateProperty(value, "Username");
        OnPropertyChanged(ref _username, value);
      }
    }

    /// <summary>
    /// Property validation method.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="name"></param>
    private void ValidateProperty<T>(T value, string name)
    {
      Validator.ValidateProperty(value, new ValidationContext(this, null, null)
      {
        MemberName = name
      });
    }
  }
}
