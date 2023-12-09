using Football_Pool_Tracker.Application.Interface;
using HtmlAgilityPack;

namespace Football_Pool_Tracker.Infrastructure.Provider
{
    public class HtmlDataProvider : IHtmlDataProvider
    {
        public HtmlNodeCollection GetNodes(uint year, uint week, string nodeName)
        {
            var link = "";
            HtmlNodeCollection? nodes = null;
            if (year == 0 || week == 0)
            { 
                link = $"https://www.footballdb.com/scores/index.html";
                var web = new HtmlWeb();
                var doc = web.Load(link);
                nodes = doc.DocumentNode.SelectNodes(nodeName);
            }
            else
            { 
                link = $"https://www.footballdb.com/scores/index.html?lg=NFL&yr={year}&type=reg&wk={week}";
                var web = new HtmlWeb();
                var doc = web.Load(link);
                nodes = doc.DocumentNode.SelectNodes(nodeName);  
            }
            return nodes;
        }
    }
}
