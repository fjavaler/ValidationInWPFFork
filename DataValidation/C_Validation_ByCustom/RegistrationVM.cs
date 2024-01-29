

namespace C_Validation_ByCustom
{
  public class RegistrationVM : ObservableObject
  {
    private string _username;
    public string Username
    {
      get { return _username; }
      set
      {
        OnPropertyChanged(ref _username, value);
      }
    }
  }
}
