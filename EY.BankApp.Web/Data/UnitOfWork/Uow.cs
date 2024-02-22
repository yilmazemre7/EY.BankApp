using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Repositories;

namespace EY.BankApp.Web.Data.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BankContext _context;

        public Uow(BankContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class,new()
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
