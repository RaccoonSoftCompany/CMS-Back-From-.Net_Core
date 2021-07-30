using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.CMS.Api.Database;
using Article.CMS.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Article.CMS.Api.Repository
{
    /// <summary>
    /// 实现CURD接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        
        private ArticleCmsdb _db;

        public EfRepository(ArticleCmsdb db)
        {
            _db=db;
        }
        
        private DbSet<T> _entity;

        protected DbSet<T> Entity
        {
            get
            {
                if (_entity == null)
                {
                    _entity = _db.Set<T>();
                }
                return _entity;
            }
        }
        
        public IQueryable<T> Table
        {
            get
            {
                return Entity.AsQueryable<T>();
            }
        }

        public void Delete(int id)
        {
            var delete = Entity.Where(x => x.Id == id).FirstOrDefault();
            _db.Remove(delete);
            _db.SaveChanges();
        }

        public void DeleteBulk(IEnumerable<int> ids)
        {
            var arr = new List<int>();
            foreach (var item in ids)
            {
                arr.Add(item);
            }
            var deleteBulk = Entity.Where(x => arr.Contains(x.Id)).ToList();
            _db.RemoveRange(deleteBulk);
            _db.SaveChanges();
        }

        public T GetId(int id)
        {
            return Entity.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.IsActived = true;
            entity.IsDeleted = false;
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedTime = DateTime.Now;

            Entity.Add(entity);
            _db.SaveChanges();
        }

        public void InsertBulk(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActived = true;
                entity.IsDeleted = false;
                entity.CreatedTime = DateTime.Now;
                entity.UpdatedTime = DateTime.Now;
            }
            Entity.AddRange(entities);
            _db.SaveChanges();
        }

        public async Task InsertBulkAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActived = true;
                entity.IsDeleted = false;
                entity.CreatedTime = DateTime.Now;
                entity.UpdatedTime = DateTime.Now;
            }
            await Entity.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.IsActived = true;
            entity.IsDeleted = false;
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedTime = DateTime.Now;

            await Entity.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdatedTime=DateTime.Now;
            _db.SaveChanges();
        }

        public void UpdateBulk(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedTime=DateTime.Now;
            }

            Entity.UpdateRange(entities);
            _db.SaveChangesAsync();
        }       
    }
}