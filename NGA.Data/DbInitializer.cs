using NGA.Core.Enum;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGA.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NGADbContext context)
        {
            context.Database.EnsureCreated();

            
           
            context.SaveChanges();
        }
    }
}
