using AngleSharp.Browser;
using AngleSharp.Html.Dom;
using OlxParser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlxParser.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("thumb"));
            
            foreach(var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
