using StockPredicter.Domain.Entities;
using StockPredicter.Domain.Interfaces;

namespace StockPredicter.Domain.Dto.Responses
{
    public record StockDataDetailsResponse(StockDetails? StockDetails) : IResponseDto;
}
