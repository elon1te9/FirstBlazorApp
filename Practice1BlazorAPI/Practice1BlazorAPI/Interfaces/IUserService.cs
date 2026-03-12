using Microsoft.AspNetCore.Mvc;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> RegistrationUser(RegUserModel newUser);
        Task<IActionResult> AuthUser(AuthUserModel authUser);
        Task<IActionResult> GetProfile(int user_id);
        Task<IActionResult> UpdateProfile(int user_id, UpdateProfile updProfile);

        Task<IActionResult> CreateNewUserAsync(RegUserModel newUser);
        Task<IActionResult> UpdateUserAsync(UpdateUser updateUser);
        Task<IActionResult> DeleteUserAsync(int id_user);
        Task<IActionResult> GetUsersListAsync();
    }
}
