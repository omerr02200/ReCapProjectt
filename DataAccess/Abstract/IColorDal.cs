using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        //List<Color> GetAll();
        //void Add(Color color);
        //void Delete(Color color);
        //void Update(Color color);
        //List<Color> GetByColorId(int colorId); //Ortak bir Generic İnterface(IEntityRepository) tanımlamasaydık, bu şekilde metodları yazardık.
    }
}
