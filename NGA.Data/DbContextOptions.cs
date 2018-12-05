using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Data
{
    public static class DbContextOptions
    {
        public static Microsoft.EntityFrameworkCore.DbContextOptions<NGA.Data.NGADbContext> Options { get; set; }
    }
}
