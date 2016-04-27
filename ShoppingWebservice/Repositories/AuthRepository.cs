﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class AuthRepository : IDisposable
    {
        private AuthContex _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository() {
            _ctx = new AuthContex();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(User userModel) {
            IdentityUser user = new IdentityUser {
                UserName = userModel.UserName,

            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password) {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose() {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}