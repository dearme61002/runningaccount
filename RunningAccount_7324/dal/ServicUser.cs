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
            string sql = "select Name,Account,Email,ID from UserInfo  where Account= @account and PWD = @pwd";
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
                    objectUserInfo.id = sr["ID"].ToString();


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

        public List<modols.AccountNote>   getAccountallNotebyuserid(string id)
        {
            string sql = "select UserID,Caption,Amount,ActType,CreateDate,Body from AccountingNote where UserID=@userid";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userid",id)
            };
           
            List<modols.AccountNote> allAccountNote = new List<AccountNote>();
            try
            {
             SqlDataReader sr=  sqlcanhelp.executeReadesql(sql, sqlParameters, false);
                while (sr.Read())
                {
                    modols.AccountNote accountNote = new AccountNote();
                    accountNote.caption = sr["Caption"].ToString();
                    accountNote.userid = sr["UserID"].ToString();
                    accountNote.amount = Convert.ToInt32(sr["Amount"]);
                    if (sr["ActType"].ToString() == "1")
                    {
                        accountNote.acttype = "支出";
                    }
                    else
                    {
                        accountNote.acttype = "收出";
                    }
                    accountNote.createdate = Convert.ToDateTime(sr["CreateDate"]);
                    accountNote.body = sr["Body"].ToString();
                    allAccountNote.Add(accountNote);
                }
               
                sr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return allAccountNote;
        }

    

    }
}
