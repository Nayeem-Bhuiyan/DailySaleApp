//using NayeemSaleApp.Services.AuthService.Interfaces;
//using NayeemSaleApp.Data;
//using NayeemSaleApp.Data.Entity;
//using NayeemSaleApp.Areas.Auth.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NayeemSaleApp.Services.AuthService
//{
//    public class UserInfoes : IUserInfoes
//    {
//        private readonly AppDbContext _context;
//        public UserInfoes(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ApplicationUser> GetUserInfoByUser(string userName)
//        {
//            return await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
//        }

//        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList()
//        {
//            var result = await (from a in _context.Users
//                                join ur in _context.UserRoles on a.Id equals ur.UserId
//                                join r in _context.Roles on ur.RoleId equals r.Id
//                                //join dl in _context.dealers on a.Id equals dl.ApplicationUserId
//                                select new AspNetUsersViewModel
//                                {
//                                    aspnetId = a.Id,
//                                    UserName = a.UserName,
//                                    Email = a.Email,
//                                    roleName = r.Name,
//                                    createdAt = a.createdAt,
//                                    isActive = a.isActive,
//                                }).ToListAsync();

//            return result;
//        }



//        public async Task<bool> DeleteRoleById(string Id)
//        {
//            _context.Roles.Remove(_context.Roles.Where(x => x.Id == Id).First());
//            return 1 == await _context.SaveChangesAsync();
//        }

//        public async Task<string> GetUserRoleByUserName(string userName)
//        {
//            var name = "";
//            var user = await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
//            var userRole = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
//            if (userRole != null)
//            {
//                var role = await _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefaultAsync();
//                name = role?.Name;
//            }
//            else { name = "no roles assingn"; }
//            return name;
//        }

//        public async Task<string> GetUserRoleByByUserId(string userId)
//        {
//            var name = "";
//            var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
//            var userRole = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
//            if (userRole != null)
//            {
//                var role = await _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefaultAsync();
//                name = role?.Name;
//            }
//            else { name = "no roles assingn"; }
//            return name;
//        }

//        public async Task<string> CheckUserName(string uname)
//        {
//            var user = await _context.Users.Where(x => x.UserName == uname).Select(x => x.UserName).FirstOrDefaultAsync();
//            if (user == null)
//            {
//                user = "Not Used";
//            }
//            return user;
//        }
//        public async Task<string> CheckEmail(string email)
//        {
//            var user = await _context.Users.Where(x => x.Email == email).Select(x => x.Email).FirstOrDefaultAsync();
//            if (user == null)
//            {
//                user = "Not Used";
//            }
//            return user;
//        }
//        public async Task<string> DeleteUser(string id)
//        {
//            try
//            {
//                var user = await _context.Users.Where(s => s.Id == id).FirstOrDefaultAsync();
//                _context.Users.Remove(user);
//                await _context.SaveChangesAsync();
//                return user.UserName;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }
//        public async Task<string> UpdateUserStatusByUserIdAndStatus(string id, int status)
//        {
//            try
//            {
//                var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
//                user.isActive = status;
//                _context.Users.Update(user);
//                await _context.SaveChangesAsync();
//                return user.UserName;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }




//    }
//}
