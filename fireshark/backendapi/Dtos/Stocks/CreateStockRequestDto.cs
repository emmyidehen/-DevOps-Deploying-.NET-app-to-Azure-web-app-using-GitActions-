using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendapi.Dtos.Stocks
{
    public class CreateStockRequestDto
    {
        public string Symbol { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = null!;
        public long MarketCap { get; set; }
    }
}