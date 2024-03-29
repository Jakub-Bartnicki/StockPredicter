﻿using StockPredicter.Domain.Dto.Utility;

namespace StockPredicter.Domain.Dto.ApiResponses
{
    public record AgregatesResponse (
        string ticker,
        int queryCount,
        int resultsCount,
        bool adjusted,
        List<AgregateResult> results,
        // create enum/sth else
        string status,
        string request_id,
        int count);
}
