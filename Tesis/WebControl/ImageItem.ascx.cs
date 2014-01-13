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

        [PersistenceMode(PersistenceMode.Attribute)]
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
            if (IsPostBack)
            {
                return;
            }
            image.ImageUrl = imageUrl;

        }

        protected void like_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity();
            activity.username = username;
            activity.activityname = "like";
            activity.typename = Type;
            activity.date = System.DateTime.UtcNow;
            var lista = (List<Activity>)Session["activity"];
            lista.Add(activity);
        }

        protected void dislike_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity();
            activity.username = username;
            activity.activityname = "dislike";
            activity.typename = type;
            activity.date = System.DateTime.UtcNow;
            var lista = (List<Activity>)Session["activity"];
            lista.Add(activity);
        }
    }
}