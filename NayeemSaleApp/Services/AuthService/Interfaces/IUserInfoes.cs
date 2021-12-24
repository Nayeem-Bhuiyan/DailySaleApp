using NayeemSaleApp.Areas.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NayeemSaleApp.Data.Entity;

namespace NayeemSaleApp.Services.AuthService.Interfaces
{
    public interface IUserInfoes
    {
        Task<ApplicationUser> GetUserInfoByUser(string userName);
        Task<bool> DeleteRoleById(string Id);
        Task<string> GetUserRoleByUserName(string userName);

        Task<string> CheckUserName(string uname);
        Task<string> CheckEmail(string email);
        Task<string> DeleteUser(string id);
        Task<string> UpdateUserStatusByUserIdAndStatus(string id, int status);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList();
        Task<string> GetUserRoleByByUserId(string userId);

    }
}
