using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Services;
using System.Web.UI.WebControls;
using Tesis.Code;
using Tesis.WebControl;

namespace Tesis
{
    public partial class feed : System.Web.UI.Page
    {


        List<Data2> posts
        {
            get
            {
                return (List<Data2>)Session["posts"];
            }
            set
            {
                Session["posts"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                posts = new List<Data2>();
                RootObject root;
                List<Like> likes;
                string sub = string.Empty;
                var username = Session["user"];
                if (username == null)
                {
                    Server.Transfer("index.aspx", true);
                }
                username = username.ToString();
                using (DataDataContext db = new DataDataContext())
                {
                    likes = db.Likes.Where(a => a.username.Equals(username)).ToList();
                }
                foreach (var like in likes)
                {
                    sub = string.Format("{0}+{1}", sub, like.likename);
                }
                root = GetjsonStream(sub);

                foreach (var children in root.data.children)
                {
                    var post = children.data;
                    if (!post.is_self && (post.domain.Contains("imgur") || post.url.EndsWith(".jpg") || post.url.EndsWith(".png") || post.url.EndsWith(".jpeg")))
                    {
                        posts.Add(post);
                    }
                }

                feedpanel.DataSource = posts;
                feedpanel.DataBind();

            }
        }

        public RootObject GetjsonStream(string type)
        {
            string json;
            var url = string.Format("http://www.reddit.com/r/{0}.json?limit=100", type);
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url);
            }
            var temp = JsonConvert.DeserializeObject<RootObject>(json);

            return temp;

        }

       

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            feedpanel.DataSource = posts;
            feedpanel.DataBind();
        }

       
        protected void like_Command(object sender, CommandEventArgs e)
        {
            string action = e.CommandName.ToString();
            string[] param = e.CommandArgument.ToString().Split(',');
            var button = (ImageButton)sender;
            button.CssClass = "selected";
            Activity activity;
            var lista = (List<Activity>)Session["activity"];
            if (Session[param[1]] != null)
            {
                activity = (Activity)Session[param[1]];
                lista.Remove(activity);
            }
            activity = new Activity();
            activity.username = Session["user"].ToString();
            activity.activityname = action;
            activity.typename = param[0];
            activity.date = System.DateTime.UtcNow;
            Session[param[1]] = activity;
            lista.Add(activity);
        }

    }
}