using getUserFromApi.Models;
using getUserFromApi.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getUserFromApi.Application.IServices
{
    public interface IConnectUserApi
    {
        
        public Task<GetAllUsersResponse> GetAllUser();

        public Task<GetUserByIdResponse> GetUserById(string UserID);

        public Task<UpdateUserResponse> Create(User User);

        public Task<UpdateUserResponse> Delete(string UserID);

        public Task<UpdateUserResponse> UpdateUserData(User User);
    }
}
