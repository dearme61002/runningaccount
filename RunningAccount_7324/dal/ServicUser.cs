using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modols;

namespace dal
{
   public class ServicUser
    {
        public modols.UserInfo login(modols.UserInfo objectUserInfo)
        {
            string sql = "select Name,Account,Email from UserInfo  where Account= @account and PWD = @pwd";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@account",objectUserInfo.account.ToString()),
                 new SqlParameter("@pwd", objectUserInfo.pwd.ToString())
        };

            try
            {
                SqlDataReader sr = sqlcanhelp.executeReadesql(sql, sqlParameters, false);
                if (sr.Read())
                {
                    objectUserInfo.name = sr["Name"].ToString();
                    objectUserInfo.email = sr["Email"].ToString();
                    objectUserInfo.account = sr["Account"].ToString();
                        
                }
                else
                {
                    objectUserInfo.name = null;
                }
                sr.Close();

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objectUserInfo;

        }



    }
}
