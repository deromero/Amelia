using System.Collections.Generic;
using System.Threading.Tasks;
using Amelia.Domain.Contracts.Services;
using Amelia.WebApp.Models;
using Amelia.WebApp.Models.Contracts;
using Amelia.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Amelia.Domain.Models;
using System;

namespace Amelia.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;

        public AccountController(
            IMembershipService membershipService,
            IUserService userService,
            ILoggingService loggingService)
        {
            _membershipService = membershipService;
            _userService = userService;
            _loggingService = loggingService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult authenticationResult = null;

            try
            {
                MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
                if (_userContext.User != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, _userContext.User.Username));
                    claims.Add(new Claim(ClaimTypes.Email, _userContext.User.Email));

                    var roles = _userService.GetUserRoles(user.Username);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Username));
                    }

                    await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                       new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });

                    authenticationResult = new GenericResult
                    {
                        Succeeded = true,
                        Message = "Authentication Succeeded",
                        ReturnValue = _userContext.User
                    };
                }
                else
                {
                    authenticationResult = new GenericResult
                    {
                        Succeeded = false,
                        Message = "Authentication Failed"
                    };
                }
            }
            catch (System.Exception exception)
            {
                authenticationResult = new GenericResult
                {
                    Succeeded = false,
                    Message = exception.Message
                };

                _loggingService.Add(new Error
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    DateCreated = DateTime.Now
                });
            }

            result = new ObjectResult(authenticationResult);
            return result;
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.Authentication.SignOutAsync("Cookies");
                return Ok();
            }
            catch (Exception ex)
            {
                _loggingService.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });

                return BadRequest();
            }

        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationViewModel user)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult registrationResult = null;

            try
            {
                if (ModelState.IsValid)
                {
                    User newUser = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                    if (newUser != null)
                    {
                        registrationResult = new GenericResult()
                        {
                            Succeeded = true,
                            Message = "Registration succeeded"
                        };
                    }
                }
                else
                {
                    registrationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid fields."
                    };
                }
            }
            catch (Exception ex)
            {
                registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingService.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
            }

            result = new ObjectResult(registrationResult);
            return result;
        }


    }
}