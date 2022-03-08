using getUserFromApi.Models;
using getUserFromApi.Application.IServices;
using getUserFromApi.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace getUserFromApi.Application
{
    public class ConnectUserApi : IConnectUserApi
    {

        private static readonly HttpClient Client = new HttpClient();
      

        //建立一個泛型可共通使用的串接api方法
        //T1因應不同的reponse結構回傳
        //T2因應不同的request資料需求
        private async Task<T1> ConnectApi<T1, T2>(HttpMethod method, string action, T2 data)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, $"https://localhost:44334/{action}");
            if (data != null)
            {
                string inputjson = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(inputjson, Encoding.UTF8, "application/json");
            }
            HttpResponseMessage response = await Client.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();

            T1 Response = JsonConvert.DeserializeObject<T1>(responseString);

            return Response;
        }

        //向api取得所有user資料
        public async Task<GetAllUsersResponse> GetAllUser()
        {
            GetAllUsersResponse Response = await ConnectApi<GetAllUsersResponse, string>(HttpMethod.Get, "GetAllUsersFromTxt", null);
            return Response;
        }

        //以userID參數向api取得單一user資料
        public async Task<GetUserByIdResponse> GetUserById(string UserID)
        {

            GetUserByIdResponse Response = await ConnectApi<GetUserByIdResponse, string>(HttpMethod.Get, $"GetUserByIdFromTxt?UserID={UserID}", null);

            return Response;

        }

        //向api新增一筆user資料
        public async Task<UpdateUserResponse> Create(User user)
        {

            UpdateUserResponse Response = await ConnectApi<UpdateUserResponse, User>(HttpMethod.Post,"CreateUserInTxt", user);

            return Response;

        }

        //以userID參數向api要求刪除一筆user資料
        public async Task<UpdateUserResponse> Delete(string UserID)
        {
            UpdateUserResponse Response = await ConnectApi<UpdateUserResponse, string>(HttpMethod.Post, $"DeleteUserInTxt?UserID={UserID}", null);
            return Response;

        }

        //向api要求更新user資料
        public async Task<UpdateUserResponse> UpdateUserData(User User)
        {
            UpdateUserResponse Response = await ConnectApi<UpdateUserResponse, User>(HttpMethod.Post, "UpdateUserInTxt", User);
            return Response;
        }
    }
}
