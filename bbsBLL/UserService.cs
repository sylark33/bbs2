using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bbsDAL;

//业务逻辑层
namespace bbsBLL
{
    public class UserService
    {
        //定义方法处理登陆请求
        public bool DoLogin(string uname, string upwd)
        {
            //调用数据访问层根据用户名和密码查询用户记录
            if ("admin".Equals(uname) && "admin".Equals(upwd))
            {
                return true;
            }
            return false;
        }
    }
}
