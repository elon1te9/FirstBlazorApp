using Practice1Blazor.Models;

namespace Practice1Blazor.Services
{
    public class UserStateService
    {
        public UserDto? CurrentUser { get; private set; }

        public bool IsAuthenticated => CurrentUser != null;
        public bool IsAdmin => CurrentUser?.id_role == 1;
        public event Action? StateChanged;

        public void SetUser(UserDto user)
        {
            CurrentUser = user;
            StateChanged?.Invoke();
        }

        public void Logout()
        {
            CurrentUser = null;
            StateChanged?.Invoke();
        }
    }
}
