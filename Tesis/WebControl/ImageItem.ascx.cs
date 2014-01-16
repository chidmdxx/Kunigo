using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tesis.Code;

namespace Tesis.WebControl
{
    public partial class ImageItem : System.Web.UI.UserControl
    {
        private string imageUrl;
        private string type;
        private string title;
        private string username;
        private Activity activity;

        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
                if (imageUrl.Contains("imgur"))
                {
                    imageUrl = imageUrl + ".jpg";
                }
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value.ToLower();
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["user"].ToString();
            activity = (Activity)Session[this.ID];
            if (IsPostBack)
            {
                return;
            }
            titlelabel.Text = title;
            image.ImageUrl = imageUrl;

        }

        protected void like_Click(object sender, EventArgs e)
        {
            var lista = (List<Activity>)Session["activity"];
            if (activity != null)
            {
                lista.Remove(activity);
                like.CssClass = "unselected";
                dislike.CssClass = "unselected";
            }
            like.CssClass = "selected";
            activity = new Activity();
            activity.username = username;
            activity.activityname = "like";
            activity.typename = Type;
            activity.date = System.DateTime.UtcNow;
            Session[this.ID] = activity;
            lista.Add(activity);
        }

        protected void dislike_Click(object sender, EventArgs e)
        {
            var lista = (List<Activity>)Session["activity"];
            if (activity != null)
            {
                lista.Remove(activity);
                like.CssClass = "unselected";
                dislike.CssClass = "unselected";
            }
            dislike.CssClass = "selected";
            activity = new Activity();
            activity.username = username;
            activity.activityname = "dislike";
            activity.typename = type;
            activity.date = System.DateTime.UtcNow;
            Session[this.ID] = activity;
            lista.Add(activity);
        }
    }
}