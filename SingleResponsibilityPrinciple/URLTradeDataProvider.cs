using System.Collections.Generic;
using System.IO;

using SingleResponsibilityPrinciple.Contracts;
using System.Net;

//Added a new class to read the trades from a remote call to the web service
namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider:ITradeDataProvider
    {
        public URLTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            string url = null;
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        private readonly Stream stream;
        private string url;
    }
}
