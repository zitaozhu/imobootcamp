using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;
using WebApplication1.model;

namespace WebApplication1.Services
{
    public class PostqresSQLService : IDatabaseService
    {
        public readonly string m_connectionstring;
        public PostqresSQLService(IConfiguration configuration)
        {
            m_connectionstring = configuration.GetValue<string>(key: "Connectionstring");
        }

        public object CommandTypes { get; private set; }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            using (var conn = new NpgsqlConnection(m_connectionstring))
            {
                await conn.OpenAsyn();
                return await conn.QueryAsync<Image>(
                    sql: "intern.image_get_all",
                    param: null,
                    commandType: CommandTypes.StoredProcedure
                );
            }


        }
    }
}