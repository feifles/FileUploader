using FileUploaderV2.Core;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FileUploaderDbContext context;

        public UnitOfWork(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
