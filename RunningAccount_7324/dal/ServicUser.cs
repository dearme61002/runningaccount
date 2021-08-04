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
            string sql = "select UserID,Caption,Amount,ActType,CreateDate,Body,ID from AccountingNote where UserID=@userid order by CreateDate desc";
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
                    accountNote.id = Convert.ToInt32(sr["ID"]);
                    accountNote.amount = Convert.ToInt32(sr["Amount"]);
                    if (sr["ActType"].ToString() == "1")
                    {
                        accountNote.acttype = "支出";
                    }
                    else
                    {
                        accountNote.acttype = "收入";
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

        public SqlDataReader getnotebyid(int id)
        {
            string sql="select Caption,Amount,ActType,Body from AccountingNote where ID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            try
            {
            return  sqlcanhelp.executeReadesql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public modols.UserInfo getUserbyuserid(string userId)
        {
            string sql = "select Account,Name,Email,UserLevel,CreateDate from UserInfo where ID = CAST( @userid as uniqueidentifier)";
          
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userid",userId)
            };
            try
            {
             SqlDataReader sr=   sqlcanhelp.executeReadesql(sql, sqlParameters, false);
                modols.UserInfo objectUserInfo = new UserInfo();
                if (sr.Read())
                {
                    objectUserInfo.account= sr["Account"].ToString();
                    objectUserInfo.name = sr["Name"].ToString();
                    objectUserInfo.email = sr["Email"].ToString();
                     if (sr["UserLevel"].ToString() == "1")
                    {
                        objectUserInfo.userlevel = "一般會員";
                    }else if(sr["UserLevel"].ToString() == "0") {
                        objectUserInfo.userlevel = "管理員";
                    }
                    objectUserInfo.createdate = Convert.ToDateTime(sr["CreateDate"]);


                    return objectUserInfo;



                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int delectnotebyid(int id)
        {
            string sql = "delete from AccountingNote where ID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            try
            {
             return   sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    public int addnotebyobjectAccountNote(modols.AccountNote objectAccountNote )
        {
            string sql = "insert into AccountingNote(UserID,Caption,Amount,ActType,Body) values(@userid,@caption,@amount,@ActType,@Body)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userid",objectAccountNote.userid),
                new SqlParameter("@caption",objectAccountNote.caption),
                new SqlParameter("@amount",objectAccountNote.amount),
                new SqlParameter("@ActType",objectAccountNote.acttype),
                new SqlParameter("@Body",objectAccountNote.body)
            };
            try
            {
             return   sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int adduserinfobyuserinfo(modols.UserInfo objectuserinfo)
        {
            string sql = "insert into UserInfo(Account,PWD,Name,Email,UserLevel) values(@Account,@PWD,@Name,@Email,@UserLevel)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Account",objectuserinfo.account),
                new SqlParameter("@PWD",objectuserinfo.pwd),
                new SqlParameter("@Name",objectuserinfo.name),
                new SqlParameter("@Email",objectuserinfo.email),
                new SqlParameter("@UserLevel",objectuserinfo.userlevel)
            };
            try
            {
              return  sqlcanhelp.executeNonQuerysql(sql, parameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int updatenotebyobjectAccountNote(modols.AccountNote accountNote ,int id)
        {
            string sql = "update AccountingNote set Caption = @caption, Amount = @amount, ActType = @acttype, Body = @body where ID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@caption",accountNote.caption),
                new SqlParameter("@acttype",accountNote.acttype),
                new SqlParameter("@body",accountNote.body),
                new SqlParameter("@amount",accountNote.amount),
             
                new SqlParameter("@id",id)

            };
            try
            {
             return   sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<modols.UserInfo> getalluserinfo()
        {
            string sql= "select ID,Account,Name,Email,UserLevel,CreateDate from UserInfo order by CreateDate desc";
            List<modols.UserInfo> userinfo = new List<UserInfo>();
            try
            {
     SqlDataReader sr=  sqlcanhelp.executeReadesql(sql);
                while (sr.Read())
                {
                    UserInfo user = new UserInfo();
                    user.id = sr["ID"].ToString();
                    user.account = sr["Account"].ToString();
                    user.name = sr["Name"].ToString();
                    user.createdate = Convert.ToDateTime(sr["CreateDate"]);
                    user.email = sr["Email"].ToString();
                    if (sr["UserLevel"].ToString() == "0")
                    {
                        user.userlevel = "管理者";
                    }
                    else
                    {
                        user.userlevel = "一般會員";
                    }
                    userinfo.Add(user);





                }
            }
            catch (Exception)
            {

                throw;
            }
            return userinfo;


        }

        public bool isexistaccountbyaccount(string account)
        {
            string sql = "select  Account  from UserInfo where Account=@account";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@account",account)
            };
            try
            {
                object result = sqlcanhelp.executeScalarsql(sql, sqlParameters, false);
            if (result != null)
            {
                return true;
            }
            else
            {
              
                return false;
            }
             
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }


}
