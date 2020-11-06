﻿using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlxParser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
