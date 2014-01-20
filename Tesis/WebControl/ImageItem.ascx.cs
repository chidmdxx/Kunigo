using System;
using System.Collections.Generic;
using Tesis.Code;

namespace Tesis.WebControl
{
    public partial class ImageItem : System.Web.UI.UserControl
    {
        private string idd;

        public string Idd
        {
            set
            {
                idd = value;
            }
            get
            {
                return idd;
            }
        }
        ImageItemContainer container
        {
            get
            {
                return (ImageItemContainer)Session[this.Idd];
            }
            set
            {
                Session[this.Idd] = value;
            }
        }
        string username
        {
            get
            {
                return container.Username;
            }
            set
            {
                container.Username = value;
            }
        }
        Activity activity
        {
            get
            {
                return container.Activity;
            }
            set
            {
                container.Activity = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return container.ImageUrl;
            }
            set
            {
                container.ImageUrl = value;
            }
        }

        public string Type
        {
            get
            {
                return container.Type;
            }
            set
            {
                container.Type = value;
            }
        }

        public string Title
        {
            get
            {
                return container.Title;
            }
            set
            {
                container.Title = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                titlelabel.Text = Title;
                image.ImageUrl = ImageUrl;
            }
            if(activity!=null)
            {
                if(activity.activityname=="like")
                {
                    like.CssClass = "selected";
                    dislike.CssClass = "unselected";
                }
                else
                {
                    like.CssClass = "unselected";
                    dislike.CssClass = "selected";
                }
            }

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
            activity.typename = Type;
            activity.date = System.DateTime.UtcNow;
            lista.Add(activity);
        }
    }
}