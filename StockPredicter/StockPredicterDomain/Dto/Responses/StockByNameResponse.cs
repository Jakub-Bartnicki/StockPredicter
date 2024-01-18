using StockPredicter.Domain.Interfaces;

namespace StockPredicter.Domain.Dto.Responses
{
    public record StockByNameResponse(List<string> StocksNames) : IResponseDto;
}
