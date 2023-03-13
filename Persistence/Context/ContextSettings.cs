using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public static class ContextSettings
    {
        public static DbContextOptions<mainContext> GetOptions(string connectionString)
        {
            DbContextOptionsBuilder<mainContext> builder = new DbContextOptionsBuilder<mainContext>();

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(connectionString);
            }

            return builder.Options;
        }
    }
}
