using asp.net_core_8._0_web_api.Configurations;
using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net_core_8._0_web_api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Age = u.Age,
            CreatedAt = u.CreatedAt
        });
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new User
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            Age = createUserDto.Age
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        user.Name = updateUserDto.Name;
        user.Email = updateUserDto.Email;
        user.Age = updateUserDto.Age;

        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}