using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.model;

namespace WebApplication1.Domains
{
    interface IDatabaseService
    {
        Task<IEnumerable<Image>> GetAllImages();
        
    }
}
