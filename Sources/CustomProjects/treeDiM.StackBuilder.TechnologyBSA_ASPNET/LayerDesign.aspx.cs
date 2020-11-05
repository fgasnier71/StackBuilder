#region Using directives
using System;
using System.Web.UI;
#endregion

public partial class LayerDesign : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
        }
    }
    #endregion
    #region Event handlers
    protected void OnPrevious(object sender, EventArgs e)
    {
        Response.Redirect("LayerDesignIntrop.aspx");
    }
    protected void OnNext(object sender, EventArgs e)
    {
        Response.Redirect("ValidationWebGL.aspx");
    }
    #endregion

}