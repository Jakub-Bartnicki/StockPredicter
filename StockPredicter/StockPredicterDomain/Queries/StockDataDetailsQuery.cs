using MediatR;
using StockPredicter.Domain.Dto.ApiResponses;
using StockPredicter.Domain.Dto.Requests;
using StockPredicter.Domain.Dto.Responses;
using StockPredicter.Domain.Dto.Utility;
using StockPredicter.Domain.Entities;
using StockPredicter.Domain.Interfaces;
using System.Text;
using System.Text.Json;

namespace StockPredicter.Domain.Queries
{
    public class StockDataDetailsQuery : IBaseQuery<StockDataDetailsResponse>
    {
        private readonly StockDataDetailsRequest _requestData;

        public StockDataDetailsQuery(StockDataDetailsRequest requestData)
        {
            _requestData = requestData;
        }

        internal class StockDataDetailsQueryHandler
            : IRequestHandler<StockDataDetailsQuery, StockDataDetailsResponse>
        {
            private readonly PolygonApiConfig _polygonApiConfig;

            public StockDataDetailsQueryHandler(PolygonApiConfig polygonApiConfig)
            {
                _polygonApiConfig = polygonApiConfig;
            }

            public async Task<StockDataDetailsResponse> Handle(StockDataDetailsQuery request, 
                CancellationToken ct)
            {
                try
                {
                    var reqData = request._requestData;
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
            }

            private string PrepareUrlRequest(StockDataDetailsQuery request, StockDataDetailsRequest reqData)
            {
                StringBuilder stringBuilder = new StringBuilder();
                var requestUrl = stringBuilder.Append(_polygonApiConfig.Url)
                    .Append(reqData.stocksTicker).Append("/range/")
                    .Append(reqData.multiplier.ToString()).Append("/")
                    .Append(reqData.timespan.ToString()).Append("/")
                    .Append(reqData.from).Append("/")
                    .Append(reqData.to).Append("?adjusted=")
                    .Append(reqData.adjusted ? "true" : "false").Append("&sort=")
                    .Append(reqData.sort).Append("&limit=")
                    .Append(reqData.limit.ToString()).Append("&apiKey=")
                    .Append(_polygonApiConfig.ApiKey)
                    .ToString();

                return requestUrl;
            }
        }
    }
}
