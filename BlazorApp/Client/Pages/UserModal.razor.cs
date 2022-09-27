using Microsoft.AspNetCore.Components;
using MudBlazor;
using UserManagement.Common.Dtos;

namespace BlazorApp.Client.Pages
{
    public partial class UserModal
    {
        
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [Parameter] public UserDto User { get; set; } = new();
        [Parameter] public bool CreationMode {get; set; }
        public void Cancel()
        {
            MudDialog.Cancel();
        }
        private async Task Save()
        {
            var result = await _userServiceManager
                .Update(new UserUpdateDto 
                { 
                    Id = User.Id, 
                    Name = User.Name, 
                    Surname = User.Surname, 
                    Patronymic = User.Patronymic, 
                    ADLogin = User.ADLogin 
                });

            if (!result.Succeeded)
            {
                _snackBar.Add(result.Messages.FirstOrDefault(),Severity.Error);
                return;
            }
            _snackBar.Add("Сохранено!", Severity.Success);
            MudDialog.Close();
        }
        private async Task Create()
        {
            var result = await _userServiceManager
                .Create(new UserCreateDto
                {
                    Name = User.Name,
                    Surname = User.Surname,
                    Patronymic = User.Patronymic,
                    ADLogin = User.ADLogin
                });

            if (!result.Succeeded)
            {
                _snackBar.Add(result.Messages.FirstOrDefault(), Severity.Error);
                return;
            }
            _snackBar.Add("Создано!", Severity.Success);
            MudDialog.Close();
        }
    }
}
