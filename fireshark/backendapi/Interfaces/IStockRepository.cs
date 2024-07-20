using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendapi.Models;

namespace backendapi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}