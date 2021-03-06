using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Intex.Models;
using Microsoft.AspNetCore.Authorization;

namespace Intex.Controllers
{
   
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;

        public object editeduser { get; private set; }

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        public ViewResult Index() => View(roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }

        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();
            foreach (IdentityUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);

        }

        //[HttpGet]
        //public IActionResult EditUsers(string userid)
        //{
        //    IdentityUser user = UserManager.Us.where(user.Id == userid);
        //    return View(user);
        //}

        public async Task<IActionResult> GrantUserPermissions(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            List<IdentityRole> permissions = new List<IdentityRole>();
            List<IdentityRole> nonPermissions = new List<IdentityRole>();
            foreach (IdentityRole role in roleManager.Roles)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? permissions : nonPermissions;
                list.Add(role);
            }
            return View(new UpdateUserPermissions
            {
                User = user,
                NonPermissions = nonPermissions,
                Permissions = permissions
            });
        }


        [HttpPost]
        public async Task<IActionResult> GrantUserPermissions(UserModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await userManager.FindByIdAsync(model.UserId);

                foreach (string roleId in model.AddIds ?? new string[] { })
                {
                    IdentityRole role = await roleManager.FindByIdAsync(roleId);
                    if (role != null)
                    {
                        result = await userManager.AddToRoleAsync(identityUser, role.Name);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string roleId in model.DeleteIds ?? new string[] { })
                {
                    IdentityRole role = await roleManager.FindByIdAsync(roleId);
                    if (role != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(identityUser, role.Name);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(ManageUsers));
            else
                return await GrantUserPermissions(model.UserId);

        }









        [HttpGet]
        public IActionResult ManageUsers()
        {
            return View(userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("ManageUsers");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("ManageUsers", userManager.Users);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
