using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityRepositoryService<T> where T:class, IEntity, new()
    {
        //List<T> GetAll();
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //T GetById(int id);

        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<T> GetById(int id);
    }
}
