using System;
using System.Linq;
using System.Collections.Generic;

using System.Net;
using System.IO;

namespace treeDiM.StackBuilder.FTPExport.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string ftpUsername = "an673754";
            string ftpPassword = "Dimtree92";
            string fileName = "testExport.csv";
            string localFile = Path.Combine(@"D:\GitHub\StackBuilder\Sources\Samples\", fileName);

            string dirUrl = "ftp://an673754@plmpack.com/public/www/stackbuilder/TechnologyBSA/download/csvFiles/";
            if (Upload(File.ReadAllBytes(localFile), dirUrl, fileName, ftpUsername, ftpPassword))
                Console.WriteLine($"{fileName} uploaded!");

            var listOfFiles = GetListOfFiles(dirUrl, ftpUsername, ftpPassword);
            foreach (var s in listOfFiles)
                Console.WriteLine(s);
        }

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
}
