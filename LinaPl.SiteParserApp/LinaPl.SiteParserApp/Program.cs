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
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection.AddConnection();
            SiteParser.ParseSite("https://kinogo.by");
            Console.ReadLine();
        }
    }
}
