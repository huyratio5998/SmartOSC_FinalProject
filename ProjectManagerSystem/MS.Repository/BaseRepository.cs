using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MsContext _context;
        protected readonly IDbSet<T> _dbset;
        public BaseRepository(MsContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        
        // xóa 1 đối tượng trong entity
        public virtual T Delete(T entity)
        {
            return _context.Set<T>().Remove(entity);
        }
        // xóa bằng id
        public virtual T Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return _context.Set<T>().Remove(entity);
        }
        // xóa nhiều đối tượng
        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _context.Set<T>().Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _context.Set<T>().Remove(obj);
        }
        // tìm kiếm  bằng id
        public virtual T GetSingleById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        // lấy về nhiều đối tượng với điều kiện
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return _context.Set<T>().Where(where).ToList();
        }

        // tính tổng số bảng ghi hay đối tượng
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Count(where);
        }
        // lấy về các đối tượng và lấy thêm được cả đối tượng được nó chứa
        // ví dụ select ra bài viết và có thể lấy ra được cả danh danh mục
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                //return query .AsQueryable();
                return query.ToList();
            }

            return _context.Set<T>().AsQueryable();
        }
        // lấy về 1 đối tượng với điều kiện 
        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public T Add(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            return result;
        }
        public T Get(int id)
        {
            var result = _context.Set<T>().Find(id);
            return result;
        }
        public T Get(string id)
        {
            var result = _context.Set<T>().Find(id);
            return result;
        }
        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      

     
            public AspNetUser Add(AspNetUser item, string Role, string Pass)
            {
                var store = new UserStore<AspNetUser>(_context);
                var manager = new UserManager<AspNetUser>(store);
                manager.Create(item, Pass);
                manager.AddToRole(item.Id, Role);
                return item;
            }




            // lấy về nhiều đối tượng sau đó phân trang
            //public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
            //{
            //    int skipCount = index * size;
            //    IQueryable<T> _resetSet;

            //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            //    if (includes != null && includes.Count() > 0)
            //    {
            //        var query = _context.Set<T>().Include(includes.First());
            //        foreach (var include in includes.Skip(1))
            //            query = query.Include(include);
            //        _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            //    }
            //    else
            //    {
            //        _resetSet = predicate != null ? _context.Set<T>().Where<T>(predicate).AsQueryable() : _context.Set<T>().AsQueryable();
            //    }

            //    resetSet = skipCount == 0 ? resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            //    total = _resetSet.Count();
            //    return _resetSet.AsQueryable();
            //}

            //public bool CheckContains(Expression<Func<T, bool>> predicate)
            //{
            //    return _context.Set<T>().Count<T>(predicate) > 0;
            //}
        }
}
