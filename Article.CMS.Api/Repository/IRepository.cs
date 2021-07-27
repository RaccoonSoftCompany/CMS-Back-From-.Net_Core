using System;
using System.Linq;
using System.Threading.Tasks;

namespace Article.CMS.Api.Repository
{
    public  interface IRepository<T> 
    {
        IQueryable<T> Table{get;} 

        T GetId (object id);

        void Insert(T entity);

        Task InsertSync(T entity);

        void InsertBulk(T entities);

        Task InsertBulkSync(T entities);

        void Delete(object id);

        void DeleteBulk(object ids);

        void Update(T entity);
        
        void UpdateBulk(T entities);


    }
}