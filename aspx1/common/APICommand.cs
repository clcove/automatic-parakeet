using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TaskSystem
{
    public class BC_APICommand
    {
        private static JObject PostData;
        // 实现方法
        public static async Task ProcessAPIResult(HttpContext content, IApplicationBuilder builder)
        {
            string returnStr = "";
            // 获取POST参数
            string parameters = "{}";
            using (StreamReader sr = new StreamReader(content.Request.Body, Encoding.UTF8))
            {
                //string content = sr.ReadToEnd();  //.Net Core 3.0 默认不再支持
                parameters = sr.ReadToEndAsync().Result;
            }
            PostData = JObject.Parse(parameters);
            // 获取APICommand
            string APICommand = GetParameterByName("APICommand");
            switch (APICommand)
            {
                case "demo":
                    {
                        returnStr = BC_APIResult.GetAPIResult("", (int)BC_APIResultStatus.UN_KNOW, "示例请求");
                        break;
                    }
                    //登录
                case "Login":
                    {
                        UserStruct user = new UserStruct();
                        user.UserName = GetParameterByName("UserName");
                        user.EncryptedPassword = GetParameterByName("Password");
                        returnStr = BC_APIResult.GetAPIResult(User.Login(user), (int)BC_APIResultStatus.SUCCESS, "登录请求");
                        break;
                    }

                default:
                    {
                        returnStr = BC_APIResult.GetAPIResult("", (int)BC_APIResultStatus.FAIL, "请检查APICommand名称是否正确!");
                        break;
                    }
            }
            await content.Response.WriteAsync(returnStr);
        }
        // 根据名称获取string类型参数
        private static string GetParameterByName(string ParameterName)
        {
            return PostData[ParameterName].ToString();
        }
    }
}