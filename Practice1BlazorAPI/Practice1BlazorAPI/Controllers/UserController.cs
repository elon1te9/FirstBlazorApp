using Microsoft.AspNetCore.Mvc;
using Practice1BlazorAPI.Interfaces;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("registrationUser")]
        public async Task<IActionResult> RegistrationUser([FromBody] RegUserModel newUser)
        {
            return await _userService.RegistrationUser(newUser);
        }

        [HttpPost]
        [Route("authUser")]
        public async Task<IActionResult> AuthUser([FromBody] AuthUserModel authUser)
        {
            return await _userService.AuthUser(authUser);
        }

        [HttpGet]
        [Route("getProfile")]
        public async Task<IActionResult> GetProfile(int user_id)
        {
            return await _userService.GetProfile(user_id);
        }

        [HttpPut]
        [Route("updateProfile")]
        public async Task<IActionResult> UpdateProfile(int user_id, [FromBody] UpdateProfile updProfile)
        {
            return await _userService.UpdateProfile(user_id, updProfile);
        }


        [HttpPost]
        [Route("createNewUser")]
        public async Task<IActionResult> CreateNewUserAsync([FromBody] RegUserModel newUser)
        {
            return await _userService.CreateNewUserAsync(newUser);
        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUser updateUser)
        {
            return await _userService.UpdateUserAsync(updateUser);
        }

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUserAsync(int id_user)
        {
            return await _userService.DeleteUserAsync(id_user);
        }

        [HttpGet]
        [Route("getUsersList")]
        public async Task<IActionResult> GetUsersListAsync()
        {
            return await _userService.GetUsersListAsync();
        }
    }
}
