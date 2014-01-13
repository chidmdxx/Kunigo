using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tesis.Code;
using Tesis.WebControl;

namespace Tesis
{
    public partial class survey : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var register = Session["register"];
            var username = Session["user"];
            Session["user"] = "chid";
            if (username == null)
            {
                Server.Transfer("index.aspx", true);
            }
            if (register == null || !(bool)register)
            {
                Server.Transfer("feed.aspx", true);
            }
            foreach (string t in App.Categories)
            {
                var si = LoadControl("~/WebControl/SurveyItem.ascx") as SurveyItem;
                si.Type = t;
                si.ID = string.Format("{0}id",t);
                si.EnableViewState = true;
                surveydata.Controls.Add(si);
            }
           

        }
       
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            List<Like> likes = new List<Like>();
            List<Dislike> dislikes = new List<Dislike>();
            foreach (var c in surveydata.Controls)
            {
                if (c is SurveyItem)
                {
                    var si = (SurveyItem)c;
                    if (si.Selected == 0)
                    {
                        Like like = new Like();
                        like.username = Session["user"].ToString();
                        like.likename = si.Type;
                        likes.Add(like);
                    }
                    else if (si.Selected == 1)
                    {
                        Dislike dislike = new Dislike();
                        dislike.username = Session["user"].ToString();
                        dislike.dislikename = si.Type;
                        dislikes.Add(dislike);
                    }
                }
            }
            using (DataDataContext db = new DataDataContext())
            {
                db.Likes.InsertAllOnSubmit(likes);
                db.Dislikes.InsertAllOnSubmit(dislikes);
                db.SubmitChanges();
            }
            Server.Transfer("feed.aspx", true);
        }
    }
}