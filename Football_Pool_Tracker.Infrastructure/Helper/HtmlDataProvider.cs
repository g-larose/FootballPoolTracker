using Football_Pool_Tracker.Application.Interface;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Pool_Tracker.Infrastructure.Helper
{
    public class HtmlDataProvider : IHtmlDataProvider
    {
        public HtmlNodeCollection GetNodes(string year, string week, string nodeName)
        {

            var link = $"https://www.footballdb.com/scores/index.html?lg=NFL&yr={year}&type=reg&wk={week}";
            var web = new HtmlWeb();
            var doc = web.Load(link);
            var nodes = doc.DocumentNode.SelectNodes(nodeName);

            return nodes;
        }
    }
}
