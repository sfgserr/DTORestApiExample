using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Documents;
using System.Windows.Input;
using DTORestApiExample.Api.DTOs;
using DTORestApiExample.Application.Commands;

namespace DTORestApiExample.Application.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel(HttpClient client) 
        {
            GetUsersCommand = new GetUsersCommand(client, this);
        }

        public ICommand GetUsersCommand { get; }

        private List<UserDTO> _users = new List<UserDTO>();

        public List<UserDTO> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

    }
}
