using DNA.Domain.Interfaces;
using DNA.Infra.Data.Context;

namespace DNA.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DNAContext _context;

        public UnitOfWork(DNAContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
