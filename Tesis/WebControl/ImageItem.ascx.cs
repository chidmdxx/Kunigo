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
        string username;

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
                type = value;
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
            image.ImageUrl = imageUrl;
            username = Session["user"].ToString();
        }

        protected void like_Click(object sender, EventArgs e)
        {
            using (DataDataContext db = new DataDataContext())
            {
                Activity activity = new Activity();
                activity.username = username;
                activity.activityname = "like";
                activity.typename = type;
                activity.date = System.DateTime.UtcNow;
                db.Activities.InsertOnSubmit(activity);
            }
        }

        protected void dislike_Click(object sender, EventArgs e)
        {
            using (DataDataContext db = new DataDataContext())
            {
                Activity activity = new Activity();
                activity.username = username;
                activity.activityname = "like";
                activity.typename = type;
                activity.date = System.DateTime.UtcNow;
                db.Activities.InsertOnSubmit(activity);
            }
        }
    }
}