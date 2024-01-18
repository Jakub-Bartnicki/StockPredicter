namespace StockPredicter.Domain.Dto.Utility
{
    public record AgregateResult(
        double v,
        double vw,
        double o,
        double c,
        double h,
        double l,
        long t,
        int n
    );
}
