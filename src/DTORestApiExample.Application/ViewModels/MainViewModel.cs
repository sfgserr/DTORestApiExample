
namespace DTORestApiExample.Application.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(AddUserViewModel addUserViewModel, UsersViewModel usersViewModel)
        {
            AddUserViewModel = addUserViewModel;
            UsersViewModel = usersViewModel;
        }

        public AddUserViewModel AddUserViewModel { get; set; }
        public UsersViewModel UsersViewModel { get; set; }
    }
}
