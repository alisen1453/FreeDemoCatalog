using IdentityServer.DataAccess;
using IdentityServer.Models;
using IdentityServer.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize(LocalApi.PolicyName)]

    public sealed class IdentityConroller(UserManager<UsersConfrim> userManager) : ControllerBase
    {
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UsersDto userDto,CancellationToken cancellationToken)
        {
            UsersConfrim usersConfrim = new()
            {
                FullName = userDto.FullName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName=userDto.UserName

            };
          IdentityResult result=  await userManager.CreateAsync(usersConfrim,userDto.Password);
            if (result== null) {

                return BadRequest(new { Message = "Kayıt Başarısız" });
               
            }
            return Ok(userDto);

        }


        [HttpPost]
        public async Task<IActionResult> LoginUser(UsersDto userDto, CancellationToken cancellationToken)
        {
            UsersConfrim? usersConfrim=await userManager.Users.FirstOrDefaultAsync(p=>
            p.Email==userDto.UserNameorEmail||p.UserName==userDto.UserNameorEmail);
            if (usersConfrim == null) {
                return BadRequest(new { Message = "Kullanıcıadı bulunamadı" });

            }
            bool result =await userManager.CheckPasswordAsync(usersConfrim, userDto.Password);
            if (result) {

                return BadRequest(new { Message = "Şifre Yanlış" });


            }
            return Ok(new { Token = "Token" });
        }

    }
}
