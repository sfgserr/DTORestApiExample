using DTORestApiExample.Application.ViewModels;
using DTORestApiExample.Domain.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

namespace DTORestApiExample.Application.Commands
{
    class AddUserCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly AddUserViewModel _viewModel;
        private readonly HttpClient _client;

        public AddUserCommand(AddUserViewModel viewModel, HttpClient client)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnCanExecuteChanged;

            _client = client;
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.CanAddUser;
        }

        public async void Execute(object? parameter)
        {
            User user = new User()
            {
                Name = _viewModel.Name,
                Email = _viewModel.Email,
                Password = _viewModel.Password,
                CreditCardNumber = _viewModel.CreditCardNumber,
            };

            string jsonUser = JsonConvert.SerializeObject(user);

            string requestUri = $"{Constants.BaseUri}api/addUser?jsonUser={jsonUser}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            await _client.SendAsync(request);
        }

        private void OnCanExecuteChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.CanAddUser)) CanExecuteChanged?.Invoke(this, e);
        }
    }
}
