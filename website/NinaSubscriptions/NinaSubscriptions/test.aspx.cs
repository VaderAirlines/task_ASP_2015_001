using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions {

    public partial class test:System.Web.UI.Page {

        protected void Page_Load(object sender,EventArgs e) {
            if (Request.QueryString["login"] != "joske") { Response.Redirect("index.aspx"); };
        }
    }
}