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
        public HtmlNodeCollection GetNodes(string nodeName)
        {

            var link = "http://www.footballdb.com";
            var web = new HtmlWeb();
            var doc = web.Load(link);
            var nodes = doc.DocumentNode.SelectNodes(nodeName);

            return nodes;
        }
    }
}
