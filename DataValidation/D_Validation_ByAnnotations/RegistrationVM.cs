using System.ComponentModel.DataAnnotations;

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
    /// <remarks>
    /// Validator.ValidateProperty references the property attributes in
    /// order to find out what criteria should be satisfied for validation.
    /// </remarks>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="name">Property name.</param>
    private void ValidateProperty<T>(T value, string name)
    {
      Validator.ValidateProperty(value, new ValidationContext(this, null, null)
      {
        MemberName = name
      });
    }
  }
}