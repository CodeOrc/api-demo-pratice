using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersListApi.Models
{
    //建立response的結構
    public class BaseResponse
    {
        public int code { get; set; }
        public string desc { get; set; }
    }

    public class GetAllUsersFromTxtResponse : BaseResponse
    {
        public List<User> data { get; set; }
    }

    public class GetUserByIdFromTxtResponse : BaseResponse
    {
        public User data { get; set; }
    }
    public class UpdateUserInTxtResponse : BaseResponse
    {
        public bool data { get; set; }
    }
}
