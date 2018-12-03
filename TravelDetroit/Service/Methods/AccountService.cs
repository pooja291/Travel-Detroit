using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TravelDetroit.Data.DAL;
using TravelDetroit.Data.Models;
using Microsoft.AspNet.Identity;

namespace TravelDetroit.Service.Methods
{
    public class AccountService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountService(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register (string name, string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _context.Users.Attach(user);
                _context.UserProfiles.Add(new UserProfile { ApplicationUser = user, Name = name });
                _context.SaveChanges();

                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return result;
        }
    }
}