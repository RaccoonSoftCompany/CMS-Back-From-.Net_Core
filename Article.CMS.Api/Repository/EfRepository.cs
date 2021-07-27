using System.Linq;
using System.Threading.Tasks;

namespace Article.CMS.Api.Repository
{
    public class EfRepository<T> : IRepository<T>
    {
        public IQueryable<T> Table => throw new System.NotImplementedException();

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBulk(object ids)
        {
            throw new System.NotImplementedException();
        }

        public T GetId(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void InsertBulk(T entities)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertBulkSync(T entities)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertSync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBulk(T entities)
        {
            throw new System.NotImplementedException();
        }
    }
}