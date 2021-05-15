using System;
using System.Net;
using System.Text;

namespace youtube_vn
{
    class Program
    {
        private static string GetName(string link)
        {
            string title;
            string args = link.Split(new string[] { "?v=", ".be/" }, StringSplitOptions.None)[1];
            string api = $"http://youtube.com/get_video_info?video_id={args}";

            string webArgs = new WebClient().DownloadString(api);
            int iqs = webArgs.IndexOf("&");

            title = WebUtility.UrlDecode(webArgs[iqs..]);
            title = title.Split(new string[] { "\"title\":" }, StringSplitOptions.None)[1];
            title = title.Split(new char[] { ',' }, StringSplitOptions.None)[0];
            title = Encoding.Default.GetString(Encoding.Default.GetBytes(title));
            title = title.Replace("\"", "").Replace("\\u0026", "\u0026");

            return title;
        }

        public static void Main(string[] args)
        {
            string link = args[0];
            string videoName = GetName(link);

            Console.WriteLine(videoName);
        }
    }
}

