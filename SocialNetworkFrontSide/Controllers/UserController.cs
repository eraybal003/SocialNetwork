using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialNetworkFrontSide.Models;
using SocialNetworkFrontSide.ViewModel;
using System.Linq;

namespace SocialNetworkFrontSide.Controllers;

public class UserController : Controller
{
	Uri baselink = new Uri("https://localhost:7170/api/");
	private readonly HttpClient _client;

    private static List<UserModel> users = new List<UserModel>();
    private static List<RoleModel> roles = new List<RoleModel>
    {
        new RoleModel { Id = Guid.NewGuid(), Name = "Seller " },
        new RoleModel { Id = Guid.NewGuid(), Name = "Customer" }
    };



    public UserController()
	{
		_client = new HttpClient();
		_client.BaseAddress = baselink;
	}

	[HttpGet]
	public IActionResult Index()
	{

        return View(users);
	}

	[HttpGet]
	public IActionResult Create()
	{
		ViewBag.Role = roles;
		return View(new UserViewModel());
	}
	[HttpPost]
	public  IActionResult Create(UserViewModel viewModel)
	{
        if (ModelState.IsValid)
        {
			var user = new UserModel
			{
				Id = Guid.NewGuid(),
				FullName = viewModel.FullName,
				Email = viewModel.Email,
				Phone = viewModel.Phone,
				Password = viewModel.Password,
				RoleId = viewModel.SelectedRoleIds.FirstOrDefault(),
				Roles = string.Join(" ,", roles.Where(r => viewModel.SelectedRoleIds.Contains(r.Id)).Select(r => r.Name))
			};
			users.Add(user);
			return RedirectToAction("Index");
        }
		ViewBag.Role = roles;
        return View(viewModel);

    }
}
