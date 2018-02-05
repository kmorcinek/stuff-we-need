namespace StuffWeNeed.Console.GitignoreUpdater
{
    public static class Downloader
    {
        public static string Download()
        {
            return Download("https://gist.githubusercontent.com/kmorcinek/2710267/raw/");
        }

        static string Download(string url)
        {
            using (var wc = new System.Net.WebClient())
            {
                return wc.DownloadString(url);
            }
        }
    }
}