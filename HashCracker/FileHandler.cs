using System;
using System.IO;
using Renci.SshNet;

namespace HashCracker
{
    public class FileHandler
    {
        public void UploadFileToRemoteHost(
            string host,
            string username,
            string password,
            string localFilePath,
            string remoteFilePath)
        {
            using (ScpClient client = new ScpClient(host, username, password))
            {
                client.Connect();
                using (Stream localFile = File.OpenRead(localFilePath))
                {
                    client.Upload(localFile, remoteFilePath);
                }
            }
        }

        public void DownloadFileToRemoteHost(
            string host,
            string username,
            string password,
            string localFilePath,
            string remoteFilePath)
        {
            using (ScpClient client = new ScpClient(host, username, password))
            {
                client.Connect();

                using (Stream localFile = File.Create(localFilePath))
                {
                    client.Download(remoteFilePath, localFile);
                }
            }
        }
    }
}
