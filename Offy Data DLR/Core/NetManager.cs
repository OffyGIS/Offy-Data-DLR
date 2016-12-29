using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Offy.Core
{
    public static class NetManager
    {
        public static bool checkInternetConnection()
        {
            var client = new WebClient();
            bool result;

            try
            {
                Stream stream = client.OpenRead("http://www.google.com");
                result = true;

                stream.Close();
                stream.Dispose();
                stream = null;
            }
            catch { result = false; }

            if (result)
            {
                client.Dispose();
                client = null;
                return result;
            }

            try
            {
                Stream stream = client.OpenRead("http://www.bing.com");
                result = true;

                stream.Close();
                stream.Dispose();
                stream = null;
            }
            catch { result = false; }

            if (result)
            {
                client.Dispose();
                client = null;
                return result;
            }

            try
            {
                Stream stream = client.OpenRead("http://www.yahoo.com");
                result = true;

                stream.Close();
                stream.Dispose();
                stream = null;
            }
            catch { result = false; }

            client.Dispose();
            client = null;

            return result;
        }

        public static bool checkUrl(DataSource ds)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = null;

            string fullUrl = ds.Url + (string.IsNullOrWhiteSpace(ds.Query) ? "" : "?" + ds.Query);

            fullUrl = fullUrl.Replace("{z}", 1.ToString());
            fullUrl = fullUrl.Replace("{x}", 1.ToString());
            fullUrl = fullUrl.Replace("{y}", 1.ToString());

            bool resourceExists = false;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(fullUrl);
                request.Method = "GET";
                request.UserAgent = "Offy Data DLR";
                request.Timeout = 20000;
                
                response = (HttpWebResponse)request.GetResponse();
                
                if (response.StatusCode == HttpStatusCode.OK
                   || response.StatusCode == HttpStatusCode.Moved
                   || response.StatusCode == HttpStatusCode.Redirect)
                    resourceExists = true;
            }
            catch(WebException e)
            {
                resourceExists = false;
            }
            finally
            {
                if (response != null) response.Close();
                response = null;
                request = null;
            }

            return resourceExists;
        }

        public static bool downloadTile(Uri uri, string path)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream inputStream = null;
            Stream outputStream = null;

            bool imgDownloaded = false;

            try
            {
                request = WebRequest.Create(uri.OriginalString) as HttpWebRequest;
                request.Method = "GET";
                request.UserAgent = "Offy Data DLR";
                request.Timeout = 20000;

                response = request.GetResponse() as HttpWebResponse;

                if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    inputStream = response.GetResponseStream();
                    outputStream = File.OpenWrite(path);

                    FileManager.copyStream(inputStream, outputStream);

                    inputStream.Dispose();
                    outputStream.Dispose();
                    inputStream = null;
                    outputStream = null;

                    imgDownloaded = true;
                }
            }
            catch (WebException e)
            {
                imgDownloaded = false;
            }
            finally
            {
                if (response != null) response.Close();
                response = null;
                request = null;
            }

            return imgDownloaded;
        }
    }
}
