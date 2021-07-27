using System;
using System.Linq;
using System.Threading.Tasks;

namespace Article.CMS.Api.Repository
{
    public  interface IRepository<T> 
    {
        //可查询的表
        IQueryable<T> Table{get;} 
        //根据获取的id，查询对应的T实例
        T GetId (object id);
        //添加数据
        void Insert(T entity);
        //异步添加数据  
        Task InsertSync(T entity);
        //批量添加数据
        void InsertBulk(T entities);
        //异步批量添加数据
        Task InsertBulkSync(T entities);
        //删除数据
        void Delete(object id);
        //批量删除数据
        void DeleteBulk(object ids);
        //更新数据
        void Update(T entity);
        //批量更新数据
        void UpdateBulk(T entities);


    }
}