using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice1BlazorAPI.Data;
using Practice1BlazorAPI.Interfaces;
using Practice1BlazorAPI.Models;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private const int user_role = 2;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> RegistrationUser(RegUserModel newUser)
        {
            var email_check = await _context.Users.AnyAsync(x => x.email == newUser.email);
            if (email_check)
                return new BadRequestObjectResult(new { error = "Email уже используется" });

            var role_check = await _context.Roles.AnyAsync(r => r.id_role == user_role);
            if (!role_check)
                return new BadRequestObjectResult(new { error = "Роли 2 н Е т" });

            var user = new User
            {
                email = newUser.email,
                name = newUser.name,
                about = newUser.about,
                password = newUser.password,
                id_role = user_role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "Пользователь зарегистрирован",
                user = new
                {
                    id_user = user.id_user,
                    email = user.email,
                    name = user.name,
                    about = user.about,
                    id_role = user.id_role
                }
            });
        }

        public async Task<IActionResult> AuthUser(AuthUserModel authUser)
        {
            var user = await _context.Users
                .Include(x => x.role)
                .FirstOrDefaultAsync(x => x.email == authUser.email && x.password == authUser.password);

            if (user == null)
                return new BadRequestObjectResult(new { error = "Неверный email или пароль" });

            return new OkObjectResult(new
            {
                status = true,
                message = "Успешный вход",
                user = new
                {
                    id_user = user.id_user,
                    email = user.email,
                    name = user.name,
                    about = user.about,
                    id_role = user.id_role,
                    role_name = user.role.name
                }
            });
        }

        public async Task<IActionResult> GetProfile(int user_id)
        {
            var user = await _context.Users
                .Include(x => x.role)
                .FirstOrDefaultAsync(x => x.id_user == user_id);

            if (user == null)
                return new NotFoundObjectResult(new { error = "Пользователь не найден" });

            return new OkObjectResult(new
            {
                status = true,
                profile = new
                {
                    id_user = user.id_user,
                    email = user.email,
                    name = user.name,
                    about = user.about,
                    id_role = user.id_role,
                    role_name = user.role.name
                }
            });
        }

        public async Task<IActionResult> UpdateProfile(int user_id, UpdateProfile updProfile)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_user == user_id);
            if (user == null)
                return new NotFoundObjectResult(new { error = "Пользователь не найден" });

            user.name = updProfile.name;
            user.about = updProfile.about;
            user.password = updProfile.password;

            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "Профиль обновлен"
            });
        }


        public async Task<IActionResult> CreateNewUserAsync(RegUserModel newUser)
        {
            var email_check = await _context.Users.AnyAsync(x => x.email == newUser.email);
            if (email_check)
                return new BadRequestObjectResult(new { error = "Email уже используется" });

            var role_check = await _context.Roles.AnyAsync(r => r.id_role == user_role);
            if (!role_check)
                return new BadRequestObjectResult(new { error = "Роли 2 н Е т" });

            var user = new User
            {
                email = newUser.email,
                name = newUser.name,
                about = newUser.about,
                password = newUser.password,
                id_role = user_role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "Пользователь создан",
                user
            });
        }

        public async Task<IActionResult> UpdateUserAsync(UpdateUser updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_user == updateUser.id_user);
            if (user == null)
                return new NotFoundObjectResult(new { error = "Пользователь не найден" });

            if (user.email != updateUser.email)
            {
                var email_check = await _context.Users.AnyAsync(x => x.email == updateUser.email);
                if (email_check)
                    return new BadRequestObjectResult(new { error = "Email уже используется" });
            }

            user.email = updateUser.email;
            user.name = updateUser.name;
            user.about = updateUser.about;
            user.password = updateUser.password;

            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "Пользователь обновлен",
                user
            });
        }

        public async Task<IActionResult> DeleteUserAsync(int id_user)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_user == id_user);
            if (user == null)
                return new NotFoundObjectResult(new { error = "Пользователь не найден" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "Пользователь удален"
            });
        }

        public async Task<IActionResult> GetUsersListAsync()
        {
            var users = await _context.Users
                .Include(x => x.role)
                .Select(x => new
                {
                    id_user = x.id_user,
                    email = x.email,
                    name = x.name,
                    about = x.about,
                    id_role = x.id_role,
                    role_name = x.role.name
                })
                .ToListAsync();

            return new OkObjectResult(new
            {
                status = true,
                users
            });

        }
    }
}
