using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.ABIS.Errors;
using Talabat.Core.Entites.Identity;

namespace Talabat.ABIS.Controllers
{

    public class AccountController : ApiBaseController
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }




        //Register
        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {


            var User = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('a')[0],
                PhoneNumber = model.PhoneNumber,

            };

            var Result = await _userManager.CreateAsync(User, model.Password);
            if (Result.Succeeded) return BadRequest(new ApiResponce(400));

            var ReturnUser = new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = "ThiswillbeToken"
            };
            return Ok(ReturnUser);


        }






        //Login



    }
}
