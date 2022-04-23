using System.Text;
using Newtonsoft.Json;

namespace TaskSystem
{
    public struct UserStruct
    {
// --    UserID INT(4) PRIMARY KEY AUTO_INCREMENT
// --  , UserName varchar(32) NOT NULL
// --  , NickName VARCHAR(32) NOT NULL
// --  , RoleID int(4) NOT NULL
// --  , Email VARCHAR(20) NOT NULL
// --  , Phone VARCHAR(20) NOT NULL
// --  , EncryptedPassword VARCHAR(64) NOT NULL
// --  , `Status` int(1) 
// --  , UpdatedBy int(4) not NULL
// --  , TimeUpdated DATETIME
// --  , CreatedBy INT(4) NOT NULL
// --  , TimeCreated DATETIME
        public int UserID{get;set;}
        public string UserName{get;set;}
        public string NickName{get;set;}
        public int RoleID{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
        public string EncryptedPassword{get;set;}
        public int Status{get;set;}
        public int UpdatedBy{get;set;}
        public string TimeUpdated{get;set;}
        public int CreatedBy{get;set;}
        public string TimeCreated{get;set;}
    }

    public class User
    {
        // 登录校验方法
        public static string Login(UserStruct user)
        {
            StringBuilder sqlB = new StringBuilder();
            sqlB.AppendLine("SELECT ");
            sqlB.AppendLine("   COUNT(1) ");
            sqlB.AppendLine("FROM users ");
            sqlB.AppendLine("WHERE users.UserName = '" + user.UserName + "' ");
            sqlB.AppendLine("AND users.EncryptedPassword = '" + user.EncryptedPassword + "' ");
            sqlB.AppendLine("; ");

            long result = Convert.ToInt64(BC_MySqlUtils.ExecuteSQLGetScalar(sqlB.ToString()));
            bool flag = false;
            if (result == 1)
            {
                flag = true;
            }
            return JsonConvert.SerializeObject(new {
                LoginStatus = flag
            });
        }
    }
}