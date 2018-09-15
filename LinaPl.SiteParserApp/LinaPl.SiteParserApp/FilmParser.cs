using AngleSharp.Parser.Html;
using Json;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using AngleSharp.Extensions;
using System.Linq;
using System.IO;

namespace LinaPl.SiteParserApp
{
    public class FilmParser
    {
        private static string _path = "D:\\Projects\\PubRepoAP\\AngelinaPloshchenko\\LinaPl.SiteParserApp\\InfoFilm.txt";
        public static StreamWriter Sw { get; set; } = File.AppendText(_path);
        public static void AddFilm(string filmURL)
        {
            var client = new HttpClient();
            var response = client.GetAsync(filmURL).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            var parser = new HtmlParser();
            var document = parser.Parse(responseString);
            var NameFilm = document.QuerySelectorAll("h1");
            var isExist = DBConnection.KeyExist(NameFilm[0].Text());

            if (!isExist)
            {
                var Extract = document.QuerySelectorAll("div.quote");
                var DescriptionFull = document.QuerySelectorAll("div.fullimg");
                if (DescriptionFull.Length == 0)
                {
                    Console.WriteLine("********************************************************");
                    return;
                }
                string[] str = DescriptionFull[0].Text().Trim().Split('\n');
                string Description = null;
                if (str != null)
                {

                    Description = str[0];
                }
                if (Extract.Length != 0 && Description != null && NameFilm.Length != 0)
                {
                    Sw.WriteLine(NameFilm[0].Text() + " " + Extract[0].Text() + " " + Description);
                   // DBConnection.AddDB(NameFilm[0].Text(), Extract[0].Text(), Description);
                }
            }
        }
    }
}
