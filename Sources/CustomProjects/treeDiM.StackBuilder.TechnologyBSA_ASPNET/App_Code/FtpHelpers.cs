#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
#endregion

/// <summary>
/// Summary description for FtpHelpers
/// </summary>
public class FtpHelpers
{
    static bool Upload(byte[] fileContent, string ftpUrl, string fileName, string ftpUsername, string ftpPassword)
    {
        try
        {
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                using (var postStream = client.OpenWrite(ftpUrl + fileName))
                {
                    postStream.Write(fileContent, 0, fileContent.Length);
                }
            }
            return true;
        }
        catch (Exception /*ex*/)
        {
            return false;
        }
    }

    static List<string> GetListOfFiles(string ftpUrl, string ftpUsername, string ftpPassword)
    {
        string names = string.Empty;

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        {
            Stream responseStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(responseStream))
            {
                names = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
        }
        return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}