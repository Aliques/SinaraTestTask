using BlazorApp.Client.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using UserManagement.Common.Dtos;
using static MudBlazor.CategoryTypes;

namespace BlazorApp.Client.Pages
{
    public partial class Users
    {
        private IEnumerable<UserDto> _users;
        private bool _loading;
        private MudTable<UserDto> mudTable;


        [Inject]
        private IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            _loading = true;
            var result = await _userServiceManager.GetAll();
            if (!result.Succeeded)
            {
                _loading = false;
                _snackBar.Add(result.Messages.FirstOrDefault(), Severity.Error);
                return;
            }
            _users = result.Data;
            _loading = false;
        }

        private async Task ChangeUserData(UserDto user)
        {
            var parameters = new DialogParameters
            {
                ["User"] = user,
                ["CreationMode"] = false
            };

            var dialog = DialogService.Show<UserModal>("Изменить", parameters,
                new DialogOptions { MaxWidth = MaxWidth.Medium });
            var result = await dialog.Result;
            await LoadData();
        }

        private async Task Delete(Guid id)
        {
            var result = await _userServiceManager.Delete(id);
            if (!result.Succeeded)
            {
                _snackBar.Add(result.Messages.FirstOrDefault(), Severity.Error);
                return;
            }
            await LoadData();
        }

        private async Task Create()
        {
            var parameters = new DialogParameters
            {
                ["CreationMode"] = true
            };

            var dialog = DialogService.Show<UserModal>("Создать", parameters);
            var result = await dialog.Result;
            await LoadData();
        }
    }
}
