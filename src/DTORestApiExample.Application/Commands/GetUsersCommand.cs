using DTORestApiExample.Api.DTOs;
using DTORestApiExample.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace DTORestApiExample.Application.Commands
{
    class GetUsersCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly HttpClient _client;
        private readonly UsersViewModel _viewModel;

        public GetUsersCommand(HttpClient client, UsersViewModel viewModel)
        {
            _client = client;
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            string requestUri = $"{Constants.BaseUri}api/getUsers";

            _viewModel.Users = await _client.GetFromJsonAsync<List<UserDTO>>(requestUri);
        }
    }
}
