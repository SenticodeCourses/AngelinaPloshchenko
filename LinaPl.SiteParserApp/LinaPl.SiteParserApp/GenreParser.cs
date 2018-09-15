using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Extensions;
using System.IO;

namespace LinaPl.SiteParserApp
{
    public class GenreParser
    {
        private static string _path = "D:\\Projects\\PubRepoAP\\AngelinaPloshchenko\\LinaPl.SiteParserApp\\RefOfFilms.txt";
        private static StreamWriter _sw;
        public static void AddGenre(string filmURL)
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException();
            }
            _sw = File.AppendText(_path);

            while (filmURL != null)
            {
                var client = new HttpClient();
                var response = client.GetAsync(filmURL).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var parser = new HtmlParser();
                var document = parser.Parse(responseString);
                var Extract = document.All.Where(m => m.ClassName == "zagolovki");

                foreach (var VARIABLE in Extract)
                {
                    var child = VARIABLE.Children;
                    foreach (var st in child)
                    {
                        _sw.WriteLine(st.GetAttribute("href"));
                        Console.WriteLine(st.GetAttribute("href"));
                        FilmParser.AddFilm(st.GetAttribute("href"));
                    }
                }

                var pages = document.QuerySelectorAll("div.bot-navigation");
                foreach (var page in pages)
                {
                    var child = page.Children;
                    foreach (var element in child)
                    {
                        var refExist = element.Text().IndexOf("Позже");
                        if (refExist != -1)
                        {
                            filmURL = element.GetAttribute("href");
                            Console.WriteLine($"!!!!!!1      {element.Text()} +++ {element.GetAttribute("href")}");
                        }
                        else
                        {
                            filmURL = null;
                        }
                    }
                }
            }
            FilmParser.Sw.Close();
            _sw.Close();
        }
    }
}
