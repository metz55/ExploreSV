using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUserAuthenticated;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mapster;
using ExploreSV.BusinessLogic.UseCases.Users.Commads.CreateUser;
using ExploreSV.BusinessLogic.UseCases.Users.Commads.DeleteUser;
using ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUser;
using ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUsers;
using ExploreSV.BusinessLogic.UseCases.Roles.Queries.GetRoles;
using System.Security.Claims;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesion(string pReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(GetUserAuthenticatedQuery getUserAuthenticatedQuery)
        {
            try
            {
                var userResponse = await _mediator.Send(getUserAuthenticatedQuery);
                if (userResponse != null && userResponse.UserName == getUserAuthenticatedQuery.userName)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, userResponse.UserName),
                        new Claim("Id", userResponse.UserId.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true });
                    return RedirectToAction("Index", "Home");
                }
                else
                    throw new Exception("Credenciales incorrectas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(getUserAuthenticatedQuery);
            }
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
        {
            var query = new GetUsersQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var users = await _mediator.Send(query);
            return View(users);
        }

        //GET: Create
        public async Task<IActionResult> Create()
        {
            var roles = await _mediator.Send(new GetRolesQuery());
            ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserCommand(createUserRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo usuario");
            }
            catch (Exception ex)
            {
                var roles = await _mediator.Send(new GetRolesQuery());
                ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
                ModelState.AddModelError("", ex.Message);
                return View(createUserRequest);
            }
        }

        //GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            if (user == null)
                return NotFound(); // Manejar caso donde el usuario no existe
            return View(user);
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UserId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserCommand(UserId));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Usuario");
                return RedirectToAction(nameof(Index)); // Redirige al index
                    
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var user = await _mediator.Send(new GetUserQuery(UserId));
                return View("Delete", user);
            }
        }
    }
}