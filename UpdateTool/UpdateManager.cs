using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateTool
{
    class UpdateManager
    {
        public static string leatestVersion;
        public static string downloadURL;

        public static async Task<int> getLeatestVersion()
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(10.0);
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                var response = await client.GetAsync("https://api.github.com/repos/kemo14331/MC-Debug-Monitor/releases/latest");
                string resString = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(resString);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    downloadURL = json["assets"][0]["browser_download_url"].ToString();
                    string name = json["name"].ToString();
                    name = name.Replace("-alpha", "");
                    name = name.Replace("-beta", "");
                    leatestVersion = name;
                    int Leatestversion = getNumberFromVersion(name);
                    return Leatestversion;
                }
                else
                {
                    MessageBox.Show("アップデートサーバーに接続できませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static int getNumberFromVersion(string name)
        {
            string[] vs = name.Split('.');
            int index = 0;
            int total = 0;
            foreach(string s in vs)
            {
                total += (int)(int.Parse(s) * Math.Pow(10, (4 - index) * 2));
                index++;
            }
            return total;
        }
    }
}
