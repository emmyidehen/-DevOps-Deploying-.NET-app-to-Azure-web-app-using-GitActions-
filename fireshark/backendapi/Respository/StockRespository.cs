using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using backendapi.Interfaces;
using backendapi.Models;

namespace backendapi.Respository
{
    public class StockRespository : IStockRepository
    {
        public Task<List<Stock>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

    }

}