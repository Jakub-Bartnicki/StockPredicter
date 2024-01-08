using MediatR;
using StockPredicter.Domain.Dto.ApiResponses;
using StockPredicter.Domain.Dto.Requests;
using StockPredicter.Domain.Dto.Responses;
using StockPredicter.Domain.Entities;
using StockPredicter.Domain.Interfaces;
using System.Text;
using System.Text.Json;

namespace StockPredicter.Domain.Queries
{
    public class StockDataDetailsQuery : IBaseQuery<StockDataDetailsResponse>
    {
        // move out static values 
        protected string url { get; } = "https://api.polygon.io/v2/aggs/ticker/";
        private string API_KEY { get; } = "e1I2UVilE7TAdKnXJgijMqeOWmxSqecy";

        private StockDataDetailsRequest RequestData { get; }

        public StockDataDetailsQuery(StockDataDetailsRequest requestData)
        {
            RequestData = requestData;
        }

        internal class StockDataDetailsQueryHandler
            : IRequestHandler<StockDataDetailsQuery, StockDataDetailsResponse>
        {
            public async Task<StockDataDetailsResponse> Handle(StockDataDetailsQuery request, 
                CancellationToken ct)
            {
                try
                {
                    var reqData = request.RequestData;
                    string requestUrl = PrepareUrlRequest(request, reqData);
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(requestUrl);
                    var stream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<AgregatesResponse>(stream);
                    return new StockDataDetailsResponse(new StockDetails(data));
                }
                catch (Exception e)
                {
                    throw;
                }
            //https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2024-01-01/2024-01-05?adjusted=true&sort=asc&limit=120&apiKey=e1I2UVilE7TAdKnXJgijMqeOWmxSqecy
            //https://api.polygon.io/v2/aggs/ticker/APPL/range/1/day/2024-01-01/2024-01-05?adjusted=True&limit=120&apiKey=e1I2UVilE7TAdKnXJgijMqeOWmxSqecy
            }

            private string PrepareUrlRequest(StockDataDetailsQuery request, StockDataDetailsRequest reqData)
            {
                StringBuilder stringBuilder = new StringBuilder();
                var requestUrl = stringBuilder.Append(request.url)
                    .Append(reqData.stocksTicker).Append("/range/")
                    .Append(reqData.multiplier.ToString()).Append("/")
                    .Append(reqData.timespan.ToString()).Append("/")
                    .Append(reqData.from).Append("/")
                    .Append(reqData.to).Append("?adjusted=")
                    .Append(reqData.adjusted ? "True" : "False").Append("&sort=")
                    .Append(reqData.sort).Append("&limit=")
                    .Append(reqData.limit.ToString()).Append("&apiKey=")
                    .Append(request.API_KEY)
                    .ToString();

                return requestUrl;
            }
        }
    }
}
