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
            DropDownListFiles.DataSource = GetAllFiles();
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

    private List<string> GetAllFiles()
    {
        try
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ConfigSettings.FtpDirectory);
            ftpRequest.Credentials = new NetworkCredential(ConfigSettings.FtpUsername, ConfigSettings.FtpPassword);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }
        catch (Exception ex)
        {
            string message = ex.ToString();
        }


        var files = new List<string>();
        files.Add("File1.csv");
        files.Add("File3.csv");
        files.Add("File4.csv");
        return files;
    }
}