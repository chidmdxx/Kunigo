using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesis.Code
{
    public class ImageItemContainer
    {
        private string imageUrl;
        private string type;
        private string title;
        private Activity activity;
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public Activity Activity
        {
            get
            {
                return activity;
            }
            set
            {
                activity = value;
            }
        }

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
        public ImageItemContainer()
        {

        }
    }
}