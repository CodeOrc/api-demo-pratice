using getUserFromApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getUserFromApi.Models.ResponseModels
{
    public class Response
    {
        public int code { get; set; }
        public string desc { get; set; }
    }

    public class GetAllUsersResponse:Response
    {
        public List<User> data { get; set; }
    }

    public class GetUserByIdResponse : Response
    {
        public User data { get; set; }
    }

    public class UpdateUserResponse : Response
    {
        public bool data { get; set; }
    }
}
