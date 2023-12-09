using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Pool_Tracker.Application.Interface
{
    public interface IHtmlDataProvider
    {
        HtmlNodeCollection GetNodes(uint year, uint week, string nodeName);
    }
}
