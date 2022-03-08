using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersListApi.Models
{
    //建立user的資料結構
    public class User
    {
        public string UserID { get; set; }
        public string PWD { get; set; }
        public string FirstName { get; set; }
        public string FirstCName { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string LastCName { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
    }
}
