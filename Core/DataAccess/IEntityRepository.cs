using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); //Belli bir kritere göre listele, kriter boş olabilir
        T Get(Expression<Func<T, bool>> filter); //Tek bir data listelemek için
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        // List<T> GetAllByCategory(int categoryId); // T Get(Expression<Func<T, bool>> filter); metodu olduğundan bu metoda gerek yoktur.
    }
}
