using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UsersListApi.Models;

namespace UsersListApi.Application
{
    public class Readtxt : IReadtxt
    {

        //讀取txt檔的方法
        public List<User> Readdata()
        {
            List<User> userlist = new List<User>();
            if (File.Exists(@"usersdata.txt"))
            {
                foreach (string line in File.ReadAllLines(@"usersdata.txt"))
                {
                    List<string> a = line.Split(';').ToList();
                    User tempuser = new User()
                    {
                        UserID = a[0],
                        PWD = a[1],
                        FirstName = a[2],
                        FirstCName = a[3],
                        Gender = a[4],
                        LastName = a[5],
                        LastCName = a[6],
                        Mail = a[7],
                        Mobile = a[8]
                    };
                    userlist.Add(tempuser);
                }
            }
            return userlist;
        }

        //覆寫txt檔的方法
        public void WriteUserdata(List<User> userlist)
        {
            List<string> fileContent = new List<string>();
            foreach (var item in userlist)
            {
                fileContent.Add($"{ item.UserID};{item.PWD};{item.FirstName};{item.FirstCName};{item.Gender};{item.LastName};{item.LastCName};{item.Mail};{item.Mobile}");
            }
            File.WriteAllLines(@"usersdata.txt", fileContent);

        }

        //實作介面
        //取得所有user資料
        public GetAllUsersFromTxtResponse GetAllUsers()
        {
            GetAllUsersFromTxtResponse getAllUsersFromTxt = new GetAllUsersFromTxtResponse() { code = 200, desc = "success", data = Readdata() };

            return getAllUsersFromTxt;
        }

        //以ID取得user資料
        public GetUserByIdFromTxtResponse GetUserById(string UserID)
        {
            List<User> userlist = Readdata();
            foreach (var item in userlist)
            {
                if (item.UserID == UserID)
                {
                    return new GetUserByIdFromTxtResponse() { code = 200, desc = "success", data = item };
                }
            }
            return new GetUserByIdFromTxtResponse() { code = 400, desc = "txt內找不到該名user", data = null };

        }

        //修改user資料
        public UpdateUserInTxtResponse UpdateUserData(User User)
        {

            List<User> userlist = Readdata();
            foreach (var item in userlist)
            {
                if (item.UserID == User.UserID)
                {
                    item.PWD = User.PWD;
                    item.FirstName = User.FirstName;
                    item.FirstCName = User.FirstCName;
                    item.Gender = User.Gender;
                    item.LastName = User.LastName;
                    item.LastCName = User.LastCName;
                    item.Mail = User.Mail;
                    item.Mobile = User.Mobile;
                    WriteUserdata(userlist);
                    return new UpdateUserInTxtResponse() { code = 200, desc = "修改資料成功", data = true };
                }
            }
            return new UpdateUserInTxtResponse() { code = 400, desc = "txt內找不到該名user", data = false };
        }


        //新增user資料
        public UpdateUserInTxtResponse Create(User user)
        {
            //後端判斷資料有否完整
            if (user.UserID.Trim() == "" || user.UserID == null)
            { return new UpdateUserInTxtResponse() { code = 400, desc = "userID不可為空", data = false }; }
            else if (user.PWD.Trim() == "" || user.PWD == null)
            { return new UpdateUserInTxtResponse() { code = 400, desc = "PWD不可為空", data = false }; }
            else
            {
                List<User> userlist = Readdata();
                foreach (var item in userlist)
                {
                    if (item.UserID == user.UserID)
                    {
                        return new UpdateUserInTxtResponse() { code = 400, desc = "userID已有人使用", data = false };
                    }
                }
                userlist.Add(user);
                WriteUserdata(userlist);
                return new UpdateUserInTxtResponse()
                { code = 200, desc = "新增user成功", data = true };
            }
        }


        //以ID刪除user
        public UpdateUserInTxtResponse Delete(string UserID)
        {
            List<User> userlist = Readdata();
            foreach (var item in userlist)
            {
                if (item.UserID == UserID)
                {
                    userlist.Remove(item);
                    WriteUserdata(userlist);
                    return new UpdateUserInTxtResponse() { code = 200, desc = "刪除成功", data = true };
                }
            }
            return new UpdateUserInTxtResponse() { code = 400, desc = "txt內找不到該名user", data = false };
        }


    }
}
