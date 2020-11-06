using OlxParser.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlxParser.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(int start, int end)
        {
            StartPoint = start;
            Endpoint = end;
        }
        public string BaseUrl { get; set; } = "https://www.olx.ua/uslugi/stroitelstvo-otdelka-remont/stroitelnye-uslugi/kiev/";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int Endpoint { get; set; }
    }
}
