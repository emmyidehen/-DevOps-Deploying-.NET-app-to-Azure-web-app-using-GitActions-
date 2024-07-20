using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backendapi.Dtos.Stocks;
using backendapi.Models;

namespace backendapi.Mappers
{
    public static class StockMappers
    {
        public static StockDtos ToStockDto(this Stock stockModel)
        {
            
            return new StockDtos
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap

            };

        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto) 
        {
            return new Stock
            {

            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
           
           };
        }
    }
}