using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.CMS.Api.Entity;

namespace Article.CMS.Api.Repository
{
    public  interface IRepository<T> where T:BaseEntity
    {
        //可查询的表
        IQueryable<T> Table{get;} 
        //根据获取的id，查询对应的T实例
        T GetId (int id);
        //添加数据
        void Insert(T entity);
        //异步添加数据  
        Task InsertSync(T entity);
        //批量添加数据
        void InsertBulk(IEnumerable<T> entities);
        //异步批量添加数据
        Task InsertBulkSync(IEnumerable<T> entities);
        //删除数据
        void Delete(int id);
        //批量删除数据
        void DeleteBulk(IEnumerable<int> ids);
        //更新数据
        void Update(T entity);
        //批量更新数据
        void UpdateBulk(IEnumerable<T> entities);


    }
}