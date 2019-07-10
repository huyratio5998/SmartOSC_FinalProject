using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        bool Update(T entity);
        T Add(T entity);
        // xóa 1 đối tượng trong entity
        T Delete(T entity);
        // xóa bằng id
        T Delete(int id);
        // xóa nhiều đối tượng
        void DeleteMulti(Expression<Func<T, bool>> where);
        // lấy về nhiều đối tượng với điều kiện
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes);
        // tính tổng số bảng ghi hay đối tượng
        int Count(Expression<Func<T, bool>> where);
        //update

        // tìm kiếm  bằng id
        T Get(int id);
        T Get(string id);
        // lấy về các đối tượng và lấy thêm được cả đối tượng được nó chứa
        // ví dụ select ra bài viết và có thể lấy ra được cả danh danh mục
        IEnumerable<T> GetAll(string[] includes = null);
        // lấy về 1 đối tượng với điều kiện 
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        //lay nhieu doi tuong, sau do phan trang
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
