using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Services;
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
            var temp=JsonConvert.DeserializeObject<RootObject>(json);

            return temp;
            
        }


        
    }
}