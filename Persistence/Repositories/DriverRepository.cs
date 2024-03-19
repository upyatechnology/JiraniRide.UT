using Application.Contracts.Persistance;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {

        public DriverRepository(JiraniDbContext dbContext): base(dbContext)
        {
            
        }

       
    }
}
