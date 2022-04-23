using AutoMapper;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public UsersController(IMapper mapper, IUnitOfWork context, UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
		{
			_mapper = mapper;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpPost("Reigster")]
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{

			var user = new IdentityUser() { Email = registerDto.Email, UserName = registerDto.Email };
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				return BadRequest(new ValidationProblemDetails(ModelState));
			}
			return NoContent();
		}
		[HttpPost("Login")]
		public async Task<ActionResult> Login(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password ,false , false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
				return BadRequest(new ValidationProblemDetails(ModelState));
			}
			return Ok("Login successfully");
		}
	}
}
