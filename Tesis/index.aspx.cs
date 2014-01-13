using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tesis.Code;
using System.Data.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tesis
{
    public partial class index : System.Web.UI.Page
    {
        



        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Response.Cookies["UserInfo"];
            if(cookie!=null)
            {
                Session["user"] = cookie["user"];
            }
            if (Session["user"] != null)
            {
                Server.Transfer("feed.aspx", true);
            }

        }

       

        public bool LogIn(string username, string password)
        {
            Security security;
            using (DataDataContext db = new DataDataContext())
            {
                var user = db.Users.SingleOrDefault(c => c.username == username);
                if (user == null)
                {
                    return false;
                }
                security = new Security(user.salt);
                security.Work(password);
                string pass = security.HashedPassword;
                if (pass.CompareTo(user.password) != 0)
                {
                    return false;
                }
                Session["user"] = user.username;
            }
            return true;
        }
        public bool SignUp(string username, string password)
        {
            Security security;
            using (DataDataContext db = new DataDataContext())
            {
                var user = db.Users.SingleOrDefault(c => c.username == username);
                if (user != null)
                {
                    return false;
                }
                user = new User();
                security = new Security();
                security.Work(password);
                user.username = username;
                user.password = security.HashedPassword;
                user.salt = security.SaltValue;
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                Session["user"] = user.username;
            }
            return true;
        }

        protected void register_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool success = SignUp(usernamesign.Text, passwordsign.Text);
                if (!success)
                {
                    usernametaken.Visible = true;
                }
                else
                {
                    Session["register"] = true;
                    Server.Transfer("survey.aspx", true);
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {

            bool success = LogIn(username.Text, password.Text);
            if (!success)
            {
                errorlogin.Visible = true;
            }
            else
            {
                var cookie = new HttpCookie("UserInfo");
                cookie["user"] = Session["user"].ToString();
                cookie.Expires = DateTime.Now.AddMonths(3);
                Response.Cookies.Add(cookie);
                Server.Transfer("feed.aspx", true);
            }

        }

    }
}