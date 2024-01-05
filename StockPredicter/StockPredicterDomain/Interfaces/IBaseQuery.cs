using MediatR;

namespace StockPredicter.Domain.Interfaces
{
    public interface IBaseQuery<T> : IRequest<T> where T : IResponseDto
    { }
}
