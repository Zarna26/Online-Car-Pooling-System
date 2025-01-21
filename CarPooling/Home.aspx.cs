using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarPoolingProject
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle page load logic if necessary
        }

        protected void btnFindRide_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindRide.aspx");
        }

        protected void btnPostRide_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostRide.aspx");
        }
    }
}
