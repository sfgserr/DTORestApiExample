using DTORestApiExample.Application.Commands;
using System.Net.Http;
using System.Windows.Input;

namespace DTORestApiExample.Application.ViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        public AddUserViewModel(HttpClient client) 
        {
            AddUserCommand = new AddUserCommand(this, client);
        }

        public ICommand AddUserCommand { get; }

        public bool CanAddUser => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) &&
                                  !string.IsNullOrWhiteSpace(Password);

		private string _name = string.Empty;

		public string Name
		{
			get => _name;
			set
            {
                Set(ref _name, value);
                OnPropertyChanged(nameof(CanAddUser));
            }
		}

        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set
            {
                Set(ref _email, value);
                OnPropertyChanged(nameof(CanAddUser));
            }
        }

        private string _password = string.Empty;

        public string Password
        {
            get => _password;
            set
            {
                Set(ref _password, value);
                OnPropertyChanged(nameof(CanAddUser));
            }
        }

        private int _creditCardNumber = 0;

        public int CreditCardNumber
        {
            get => _creditCardNumber;
            set
            {
                Set(ref _creditCardNumber, value);
                OnPropertyChanged(nameof(CanAddUser));
            }
        }
    }
}
