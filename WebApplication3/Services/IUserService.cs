using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int userId);
}

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<User>> GetAll() => 
        await _db.Users
            .Include(u => u.Role)
            .ToListAsync();

    public async Task<User?> GetById(int userId) =>
        await _db.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == userId);
}
