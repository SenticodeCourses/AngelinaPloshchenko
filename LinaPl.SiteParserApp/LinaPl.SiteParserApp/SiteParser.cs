using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Extensions;

namespace LinaPl.SiteParserApp
{
    class SiteParser
    {
        public static void ParseSite(string siteURL)
        {
            var client = new HttpClient();
            var response = client.GetAsync(siteURL).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            var parser = new HtmlParser();
            var document = parser.Parse(responseString);
            var AllCategories = document.QuerySelectorAll("div.mini");
            foreach (var category in AllCategories)
            {
                var categoryContainer = category.Children;
                foreach (var element in categoryContainer)
                {
                    var refExist = element.Text().IndexOf("Мобил");
                    if (refExist == -1)
                    {
                        Console.WriteLine(element.GetAttribute("href") + "*******************************************************");
                        if (element.GetAttribute("href") != null)
                        {
                            GenreParser.AddGenre("https://kinogo.by" + element.GetAttribute("href"));
                        }
                    }
                }
            }
        }
    }
}
