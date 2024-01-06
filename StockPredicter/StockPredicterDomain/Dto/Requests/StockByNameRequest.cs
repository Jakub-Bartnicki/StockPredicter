using StockPredicter.Domain.Interfaces;

namespace StockPredicter.Domain.Dto.Requests
{
    public record StockByNameRequest(string Name) : IRequestDto;
}
