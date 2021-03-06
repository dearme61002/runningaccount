using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using modols;

namespace dal
{
    //應用層這是用來用可以應用的程式庫這裡的成員都是更改資料庫的方法只能被UI層訪問
    public class ServicUser
    {/// <summary>
    /// 登入時會用的的方法
    /// </summary>
    /// <param name="objectUserInfo"></param>
    /// <returns></returns>
        public modols.UserInfo login(modols.UserInfo objectUserInfo)
        {
            string sql = "select Name,Account,Email,ID,UserLevel from UserInfo  where Account= @account and PWD = @pwd";
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
                    objectUserInfo.userlevel = sr["UserLevel"].ToString();


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
        /// <summary>
        /// 得到流水帳的資料的方法利用ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<modols.AccountNote> getAccountallNotebyuserid(string id)
        {
            string sql = "select UserID,Caption,Amount,ActType,CreateDate,Body,ID from AccountingNote where UserID=@userid order by CreateDate desc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userid",id)
            };

            List<modols.AccountNote> allAccountNote = new List<AccountNote>();
            try
            {
                SqlDataReader sr = sqlcanhelp.executeReadesql(sql, sqlParameters, false);
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
        /// <summary>
        /// 得到流水帳的方法利用ID但得到的SqlDataReader
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SqlDataReader getnotebyid(int id)
        {
            string sql = "select Caption,Amount,ActType,Body from AccountingNote where ID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            try
            {
                return sqlcanhelp.executeReadesql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 得到用戶的方法id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public modols.UserInfo getUserbyuserid(string userId)
        {
            string sql = "select Account,Name,Email,UserLevel,CreateDate from UserInfo where ID = CAST( @userid as uniqueidentifier)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userid",userId)
            };
            try
            {
                SqlDataReader sr = sqlcanhelp.executeReadesql(sql, sqlParameters, false);
                modols.UserInfo objectUserInfo = new UserInfo();
                if (sr.Read())
                {
                    objectUserInfo.account = sr["Account"].ToString();
                    objectUserInfo.name = sr["Name"].ToString();
                    objectUserInfo.email = sr["Email"].ToString();
                    if (sr["UserLevel"].ToString() == "1")
                    {
                        objectUserInfo.userlevel = "一般會員";
                    }
                    else if (sr["UserLevel"].ToString() == "0")
                    {
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
        /// <summary>
        /// 檢查密碼存在的方法
        /// </summary>
        /// <param name="oldPas"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool thispasisexitbyOldpasandId(string oldPas, string id)
        {
            string sql = "select count(1) from UserInfo  where ID= CAST( @id as uniqueidentifier) and PWD =@pwd";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@pwd",oldPas)
            };
            try
            {
                int result = Convert.ToInt32(sqlcanhelp.executeScalarsql(sql, sqlParameters, false));
                if (result > 0)
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
        /// <summary>
        /// 刪除筆記的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int delectnotebyid(int id)
        {
            string sql = "delete from AccountingNote where ID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            try
            {
                return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 加入筆記的方法
        /// </summary>
        /// <param name="objectAccountNote"></param>
        /// <returns></returns>
        public int addnotebyobjectAccountNote(modols.AccountNote objectAccountNote)
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
                return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 加入客戶的方法
        /// </summary>
        /// <param name="objectuserinfo"></param>
        /// <returns></returns>
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
                return sqlcanhelp.executeNonQuerysql(sql, parameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 跟改筆記的方法
        /// </summary>
        /// <param name="accountNote"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updatenotebyobjectAccountNote(modols.AccountNote accountNote, int id)
        {
            string sql = "update AccountingNote set Caption = @caption, Amount = @amount, ActType = @acttype, Body = @body where ID = @id";
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
                return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 跟改密碼的方法
        /// </summary>
        /// <param name="newpaw"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updatePAWbyid(string newpaw,string id)
        {
            string sql = "update UserInfo  set PWD=@pwd where ID = CAST(@id as uniqueidentifier)"; 
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@pwd",newpaw),
            new SqlParameter("@id",id)
            };
            try
            {
           return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 刪除客戶的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteinfobyID(string id)
        {
            string sql = "delete from UserInfo where ID =CAST(@id as uniqueidentifier)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            try
            {
                return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 跟改客戶資料的方法
        /// </summary>
        /// <param name="objectuserInfo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updateuserinfobyobjecInfo(modols.UserInfo objectuserInfo, string id)
        {
            string sql = "update UserInfo set Name = @Name, Email = @Email,UserLevel=@UserLeve where ID = CAST( @id as uniqueidentifier)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Name",objectuserInfo.name),
                new SqlParameter("@Email",objectuserInfo.email),
                new SqlParameter("@UserLeve",objectuserInfo.userlevel),
                new SqlParameter("@id",id)

            };
            try
            {
                return sqlcanhelp.executeNonQuerysql(sql, sqlParameters, false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 得到所有客戶的資料的方法
        /// </summary>
        /// <returns></returns>
        public List<modols.UserInfo> getalluserinfo()
        {
            string sql = "select ID,Account,Name,Email,UserLevel,CreateDate from UserInfo order by CreateDate desc";
            List<modols.UserInfo> userinfo = new List<UserInfo>();
            try
            {
                SqlDataReader sr = sqlcanhelp.executeReadesql(sql);
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
        /// <summary>
        /// 檢查客戶帳號存在的方法
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 得到所有統計好的方法
        /// </summary>
        /// <returns></returns>
        public modols.data getdate()
        {
            modols.data mydata = new modols.data();
            string sql = "select top 1 CreateDate from AccountingNote";
            try
            {
              mydata.firstuse= Convert.ToDateTime(sqlcanhelp.executeScalarsql(sql)) ;
                mydata.lastuse = Convert.ToDateTime(sqlcanhelp.executeScalarsql("select top 1 CreateDate from AccountingNote order by CreateDate desc"));
                mydata.usecount = Convert.ToInt32(sqlcanhelp.executeScalarsql("select count(1) from AccountingNote"));
                mydata.userallcount = Convert.ToInt32(sqlcanhelp.executeScalarsql("select count(1) from UserInfo  "));

            }
            catch (Exception)
            {

                throw;
            }
            return mydata;
        }
    }


}
