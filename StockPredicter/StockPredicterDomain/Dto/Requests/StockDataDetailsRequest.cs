using StockPredicter.Domain.Dto.Utility;
using StockPredicter.Domain.Interfaces;

namespace StockPredicter.Domain.Dto.Requests
{
    public record StockDataDetailsRequest(
        string stocksTicker,
        string from,
        string to,
        Timespan timespan = Timespan.day,
        int multiplier = 1,
        string sort = "asc",
        int limit = 120,
        bool adjusted = true
        ) : IRequestDto;
}
