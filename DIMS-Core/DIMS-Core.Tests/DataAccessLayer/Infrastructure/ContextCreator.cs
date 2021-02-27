using System;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.DataAccessLayer.Infrastructure
{
    public static class ContextCreator
    { 
        public static DIMSCoreContext CreateContext() 
        {
            var options = new DbContextOptionsBuilder<DIMSCoreContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;
            return new DIMSCoreContext(options);
        }
    }
}
