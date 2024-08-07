using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendapi.Data;
using backendapi.Models;
using backendapi.Dtos.Stocks;
using backendapi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly Applicationdbcontext _stockDb;
        private readonly Applicationdbcontext _context;

        public StockController(Applicationdbcontext context, Applicationdbcontext stockDb)
    {
        _stockDb = stockDb ?? throw new ArgumentNullException(nameof(stockDb));
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockDb.Stock.ToListAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stocks = await _stockDb.Stock.FindAsync(id);

            if (stocks == null)
            {
                return NotFound();
            }

            return Ok(stocks.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDto StockDtos)
        {

         var stockModel = StockDtos.ToStockFromCreateDto();
         if (_context == null)
        {
            throw new InvalidOperationException("DbContext is not initialized.");
        }
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
          var stockModel = await _context.Stock.FirstOrDefaultAsync (x => x.Id == id);

          if (stockModel == null)
          {
            return NotFound();
          }

          stockModel.Symbol = updateDto.Symbol;
          stockModel.CompanyName = updateDto.CompanyName;
          stockModel.Purchase = updateDto.Purchase;
          stockModel.LastDiv = updateDto.LastDiv;
          stockModel.Industry = updateDto.Industry;
          stockModel.MarketCap = updateDto.MarketCap;

          await _context.SaveChangesAsync();

          return Ok(stockModel.ToStockDto());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync (x => x.Id == id);

            if (stockModel == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stockModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    
    }
}