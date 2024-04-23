using IdentityAuthLesson.DTOs;
using IdentityAuthLesson.Filters;
using IdentityAuthLesson.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IdentityAuthLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [CustomResourseFilter]
        public async Task<ActionResult<ResponseDTO>> CreateRole(RoleDTO role)
        {
            
            var result = await _roleManager.FindByNameAsync(role.RoleName);
                
            if (result == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                return Ok(new ResponseDTO
                {
                    Message = "Role Created",
                    IsSuccess = true,
                    StatusCode = 201
                });
            }

            return Ok(new ResponseDTO
            {
                Message = "Role cann not created",
                StatusCode = 403
            });
        }


        [HttpGet]
        [Custom]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }



        [HttpDelete]
        [Delete]
        [CustomResultFilter]
        public async Task<IActionResult> DeleteRoleById(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest("Error occured");
            }
            return Ok($"Role '{role.Name}' deleted successfully.");
        }




        [HttpPut]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateRoleById(string Id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            role.Name = roleName;

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest("Error occured");
            }
            return Ok($"Role updated to '{roleName}'.");
        }
    }
}
