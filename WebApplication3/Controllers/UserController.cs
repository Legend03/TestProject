using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _userService.GetAll());
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> Detail(int userId)
    {
        return View(await _userService.GetById(userId));
    }
}