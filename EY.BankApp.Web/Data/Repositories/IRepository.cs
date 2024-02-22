using System.Linq;

namespace EY.BankApp.Web.Data.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Remove(T entity);
        public T GetById(object id);

        List<T> GetAll();
        void Update(T entity);

        IQueryable<T> GetQueryable();

    }
}
