#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
#endregion

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListFiles.DataSource = FtpHelpers.GetListOfFiles(ConfigSettings.FtpDirectory, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword);
            DropDownListFiles.DataBind();
        }
    }

    protected void OnNewProject(object sender, EventArgs e)
    {
        Response.Redirect("LayerSelection.aspx");
    }

    protected void OnOpenProject(object sender, EventArgs e)
    {
        Response.Redirect("Validation.aspx");
    }
}