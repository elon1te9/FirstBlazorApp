using Practice1Blazor.Models;
using Practice1Blazor.Requests;
using System.Net.Http.Json;
using System.Text.Json;

namespace Practice1Blazor.Services
{
    public class ApiRequestService
    {
        private readonly HttpClient _http;

        public ApiRequestService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AuthResponse?> AuthUser(AuthUserModel model)
        {
            var response = await _http.PostAsJsonAsync("authUser", model);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AuthResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<UsersListResponse?> GetUsersList()
        {
            var json = await _http.GetStringAsync("getUsersList");

            return JsonSerializer.Deserialize<UsersListResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ApiResponse?> DeleteUser(int id_user)
        {
            var response = await _http.DeleteAsync($"deleteUser?id_user={id_user}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ApiResponse?> CreateNewUser(RegUserModel model)
        {
            var response = await _http.PostAsJsonAsync("createNewUser", model);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ApiResponse?> UpdateUser(UpdateUserModel model)
        {
            var response = await _http.PutAsJsonAsync("updateUser", model);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ProfileResponse?> GetProfile(int user_id)
        {
            var json = await _http.GetStringAsync($"getProfile?user_id={user_id}");

            return JsonSerializer.Deserialize<ProfileResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResponse?> UpdateProfile(int user_id, UpdateProfileModel model)
        {
            var response = await _http.PutAsJsonAsync($"updateProfile?user_id={user_id}", model);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<RegResponse?> RegisterUser(RegUserModel model)
        {
            var response = await _http.PostAsJsonAsync("registrationUser", model);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RegResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<MovieListResponse> GetMoviesListAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<MovieListResponse>("api/movies");
            }
            catch
            {
                return null;
            }
        }

        public async Task<MovieResponse?> GetMovieByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<MovieResponse>($"api/movies/{id}");
            }
            catch
            {
                return null;
            }
        }
        public async Task<GenreListResponse?> GetGenreListAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<GenreListResponse>("api/genres");
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateMovieAsync(CreateMovieModel model)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/movies", model);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateMovieAsync(int id, UpdateMovieModel model)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/movies/{id}", model);
                return response.IsSuccessStatusCode;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/movies/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
