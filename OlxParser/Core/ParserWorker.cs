using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlxParser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;

        #region
        public IParser<T> Parser { get; set; }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }

        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion Properties 

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;


        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }
        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void Aborte()
        {
            isActive = false;
        }
        public async void Worker()
        {
            for(int i = parserSettings.StartPoint; i <= parserSettings.Endpoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source = await loader.GetSourceByPage(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }

            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
