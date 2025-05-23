using DAL.Context;
using DAL.Repositories.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class OrdersRepository  : Repository<OrdersEntity>, IOrdersRepository
    {
        public OrdersRepository(IDbConnection connection) : base(connection) { }
    }
}
