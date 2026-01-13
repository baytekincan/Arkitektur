using Arkitektur.DataAccess.Context;

namespace Arkitektur.DataAccess.UOW
{
    public class UnitOfWork(AppDbContext arkitekturContext) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAsync()
        {
            return await arkitekturContext.SaveChangesAsync() > 0;
        }
    }
}
