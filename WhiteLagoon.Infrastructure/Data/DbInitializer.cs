﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interface;

namespace WhiteLagoon.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public DbInitializer(ApplicationDbContext db,RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        

        public void Initializer()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
                if(_roleManager .RoleExistsAsync(SD.Role_Admin ).GetAwaiter().GetResult()) {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).Wait();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
