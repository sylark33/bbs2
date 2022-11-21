using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//数据访问层，连接数据库
namespace bbsDAL
{
    public class UserManager
    {
        //处理用户登陆请求
        public int getLoginUser(string uname, string upwd)
        {
            int result = 0;
            //1、定义连接字符串
            string constr = "Data Source=.;Initial Catalog=Craft; Integrated Security=True";
            //2、创建Connection对象：连接字符串

            SqlConnection sqlConnection = new SqlConnection(constr);
            //3、打开数据库连接

            //4、定义sql语句

            //5、创建command对象：传sql语句、Connection对象

            //6、调用command对象方法执行sql语句 获取结果

            //7、处理结果

            //8、关闭资源

            return result;
        }
    }
}




