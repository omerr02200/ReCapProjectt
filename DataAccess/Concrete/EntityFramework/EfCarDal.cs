using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        //public void Add(Car entity)
        //{
        //    using (ReCapDatabaseContext context=new ReCapDatabaseContext())
        //    {
        //        var addedEntity = context.Entry(entity); //Parametrede verilen değeri veri tabanındaki ile eşleştir(referansı yakala). Yeni bir
        //        //ekleme yapılacağından eşleştirmeyip, ekleme yapacak. Bunun için aşağıdaki kod yazılır.
        //        addedEntity.State = EntityState.Added; //Değişkenin durumunu EntityState in Added metoduna eşitle
        //        context.SaveChanges(); //Değişikleri kaydet.
        //        Console.WriteLine(entity.Description + " aracı eklendi");
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (ReCapDatabaseContext context=new ReCapDatabaseContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}
        //public void Update(Car entity)
        //{
        //    using (ReCapDatabaseContext context=new ReCapDatabaseContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        //    }
        //}
        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    }
        //} //Core katmanında DataAccess klasöründe EntityFramework klasöründe oluşturduğumuz ortak Generic sınıf olan, hem Entity hem de Context içeren
        //EfEntityRepositoryBase sınıfına bu kodları yazarak, her tablonun Ef'üne her seferinde aynı kodları yazmamıza gerek kalmaz. Aynı metodları içeren
        //ICarDal'ı da implemente etmemizin sebebi ileride sadece bu tabloya özgü erişim sağlamak istediğimiz detaylı veriler için metod tanımla gereğidir.

        //Bir sınıftaki veriler ile diğer sınıftaki verileri bir araya getirme ihitiyacını DTO ile sağlarız. Bunun için Entities katmanında
        //DTOs adlı bir klasör ekleyerek ihitiyacımız olan sınıfları bu klasöre ekleriz.
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = x.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            } 
        }
    }
}
