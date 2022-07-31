namespace WebApplication3.Models;

public class Role
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<User>? Users { get; set; }
}