using MediatR;
using StockPredicter.Domain.Dto.Requests;
using StockPredicter.Domain.Dto.Responses;
using StockPredicter.Domain.Entities;
using StockPredicter.Domain.Interfaces;

namespace StockPredicter.Domain.Queries
{
    public class StockByNameQuery : IBaseQuery<StockByNameResponse>
    {
        public StockByNameRequest RequestData { get; set; }

        public StockByNameQuery(StockByNameRequest request)
        {
            RequestData = request;
        }

        internal class StockByNameQueryHandler : IRequestHandler<StockByNameQuery, StockByNameResponse>
        {
            public async Task<StockByNameResponse> Handle(StockByNameQuery request, CancellationToken ct)
            {
                var array = new List<StockDetails>();
                array.Add(new StockDetails("APP"));
                return new StockByNameResponse(array);
            }
        }
    }
}
