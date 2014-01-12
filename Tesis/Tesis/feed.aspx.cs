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
            List<Thread> threads = new List<Thread>();
            List<Data2> posts = new List<Data2>();
            List<Like> likes; 
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
                var temp = like.likename;
                Thread thread = new Thread(() => GetjsonStream(temp));
                thread.Start();
                threads.Add(thread);
            }
            foreach(var t in threads)
            {
                t.Join();
            }
            foreach(var r in roots)
            {
                var post = r.data.children[0].data;
                if (!post.is_self)
                {
                    posts.Add(post);
                }
                if(posts.Count>100)
                {
                    break;
                }
            }
            posts.OrderBy(p => p.score);
            var count=0;
            foreach(var p in posts)
            {
                var ii = LoadControl("~/WebControl/ImageItem.ascx") as ImageItem;
                ii.ID = count++.ToString();
                ii.ImageUrl = p.url;
                ii.Title = p.title;
                feedpanel.Controls.Add(ii);
            }
        }

        public void GetjsonStream(string type)
        {
            string json;
            var url = string.Format("http://www.reddit.com/r/{0}.json", type);
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