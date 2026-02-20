using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Models;

namespace asp.net_core_8._0_web_api.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task<bool> DeleteUserAsync(int id);
}