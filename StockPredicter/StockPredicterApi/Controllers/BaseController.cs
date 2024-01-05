using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockPredicter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;
        protected readonly IMediator _mediator;

        public BaseController(ILogger<T> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [NonAction]
        protected async Task<IActionResult> Command<U>(U command)
        {
            var result = await Execute(command);
            return Json(result);
        }

        [NonAction]
        protected async Task<IActionResult> Query<U>(U query)
        {
            var result = await Execute(query);
            return Json(result);
        }

        [NonAction]
        protected async Task<object> Execute<U>(U request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch
            {
                return null;
            }
        }

        [NonAction]
        protected IActionResult Json<U>(U data)
        {
            if (data is Unit)
            {
                return NoContent();
            }
            else if (data is not null)
            {
                return Ok(data);
            }

            return BadRequest(data);
        }
    }
}
