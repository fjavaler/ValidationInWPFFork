using System.Globalization;
using System.Windows.Controls;

namespace C_Validation_ByCustom
{
  public class MinimumCharacterRule : ValidationRule
  {
    #region Properties
    /// <summary>
    /// The minimum number of characters allowed.
    /// </summary>
    public int MinimumCharacters { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Validation method.
    /// </summary>
    /// <param name="value">User input to validate.</param>
    /// <param name="cultureInfo">?</param>
    /// <returns>Validation result indicating success/failure.</returns>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      string charString = value as string;

      if (charString.Length < MinimumCharacters)
        return new ValidationResult(false, $"User at least {MinimumCharacters} characters.");

      return new ValidationResult(true, null);
    }
    #endregion
  }
}