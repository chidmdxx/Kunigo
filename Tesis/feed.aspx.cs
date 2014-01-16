using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tesis.Code;
using Tesis.WebControl;

namespace Tesis
{
    public partial class feed : System.Web.UI.Page
    {
        
        List<RootObject> roots = new List<RootObject>();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Data2> posts = new List<Data2>();
            List<Like> likes;
            string sub=string.Empty;
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
            foreach(var like in likes)
            {
               sub=string.Format("{0}+{1}",sub,like.likename);              
            }
            GetjsonStream(sub);            
            foreach(var r in roots)
            {
                foreach (var children in r.data.children)
                {
                    var post = children.data;
                    if (!post.is_self && (post.domain.Contains("imgur") || post.url.EndsWith(".jpg") || post.url.EndsWith(".png") || post.url.EndsWith(".jpeg")))
                    {
                        posts.Add(post);
                    }
                }
            }
            var count=0;
            foreach(var p in posts)
            {
                var ii = LoadControl("~/WebControl/ImageItem.ascx") as ImageItem;
                ii.ID = count++.ToString();
                ii.ImageUrl = p.url;
                ii.Title = p.title;
                ii.Type = p.subreddit;
                feedpanel.Controls.Add(ii);
            }
        }

        public void GetjsonStream(string type)
        {
            string json;
            var url = string.Format("http://www.reddit.com/r/{0}.json?limit=100", type);
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url);
            }
            var temp=JsonConvert.DeserializeObject<RootObject>(json);
            lock (roots)
            {
                roots.Add(temp);
            }
        }
    }
}