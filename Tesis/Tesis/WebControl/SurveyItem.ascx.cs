using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tesis.Code;

namespace Tesis.WebControl
{
    public partial class SurveyItem : System.Web.UI.UserControl
    {

        private string type;
        public string Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }
        public int Selected
        {
            get
            {
                return int.Parse(buttonlist.SelectedValue);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp = type;
            buttonlist.ID = string.Format("{0}buttonlist", type);
            if (temp.Contains("porn"))
            {
                temp = temp.Replace("porn", "");
            }
            label.Text = string.Format("Do you like {0} images?", temp);

            buttonlist.SelectedIndex = 2;


        }
    }
}