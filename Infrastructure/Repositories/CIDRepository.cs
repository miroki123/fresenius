using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CIDRepository : Repository<Tb_CID>
    {
        public CIDRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
