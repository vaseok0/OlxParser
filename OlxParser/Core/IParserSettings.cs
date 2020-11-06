using System;
using System.Collections.Generic;
using System.Text;

namespace OlxParser.Core
{
    interface IParserSettings
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; }

        public int StartPoint { get; set; }
        public int Endpoint { get; set; }
    }
}
