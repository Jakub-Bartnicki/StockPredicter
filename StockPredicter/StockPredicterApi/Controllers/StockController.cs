using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockPredicter.Domain.Dto.Requests;
using StockPredicter.Domain.Queries;

namespace StockPredicter.Api.Controllers
{
    public class StockController : BaseController<StockController>
    {
        public StockController(ILogger<StockController> logger, IMediator mediator) : base(logger, mediator)
        { }

        [HttpGet("search/{name}")]
        public Task<IActionResult> GetStocksByName(string name)
        {
            var request = new StockByNameRequest(name);
            var query = new StockByNameQuery(request);
            var result = Query(query);

            return result;
        }
    }
}
