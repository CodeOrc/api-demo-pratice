using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersListApi.Models;

namespace UsersListApi.Application
{
    //建立各種基本功能介面
    public interface IReadtxt
    {
        public GetAllUsersFromTxtResponse GetAllUsers();

        public GetUserByIdFromTxtResponse GetUserById(string UserID);

        public UpdateUserInTxtResponse Create(User user);

        public UpdateUserInTxtResponse Delete(string UserID);

        public UpdateUserInTxtResponse UpdateUserData(User User);
    }
}
