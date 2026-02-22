using Microsoft.EntityFrameworkCore;
using SpecKitDemoApi.Data;
using SpecKitDemoApi.Models;

namespace SpecKitDemoApi.Services;

public interface IUserService
{
    Task<List<User>> GetUsersAsync();
}

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}

