using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.CMS.Api.Entity;

namespace Article.CMS.Api.Repository
{
    /// <summary>
    /// CURD接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  interface IRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// 可查询的表
        /// </summary>
        /// <value></value>
        IQueryable<T> Table{get;} 

        /// <summary>
        /// 根据获取的id，查询对应的T实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetId (int id);

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// 异步添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        Task InsertAsync(T entity);
        
        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="entities"></param>
        void InsertBulk(IEnumerable<T> entities);

        /// <summary>
        /// 异步批量添加数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task InsertBulkAsync(IEnumerable<T> entities);

        //删除数据
        void Delete(int id);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="ids"></param>
        void DeleteBulk(IEnumerable<int> ids);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        void UpdateBulk(IEnumerable<T> entities);


    }
}