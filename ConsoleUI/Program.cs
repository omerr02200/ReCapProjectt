using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //brandManager brandManager = new brandManager();
            //foreach (var car in brandManager.GetAll())
            //{
            //    Console.WriteLine(car.CarId);
            //    Console.WriteLine(car.Description);
            //} //Injection yapılmamışsa

            //brandManager brandManager = new brandManager(new InMemoryCarDal());

            //foreach (var car in brandManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            // CarTest();

            // BrandTest();

            // ColorTest();

            // UserTest();

             // CustomerTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result2 = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now.Date });
            Console.WriteLine(result2.Message);

            //var result = rentalManager.GetAll().Data;
            //foreach (var rental in result)
            //{
            //    Console.WriteLine(rental.RentDate.ToString());
            //}

            //var result = rentalManager.GetAll().Data.OrderByDescending(r => r.RentDate).FirstOrDefault();
            //Console.WriteLine(result.RentDate);


            Console.ReadLine();

        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.Write(car.Description + ", BrandId=" + car.BrandId + ", ColorId=" + car.ColorId + "\n");
            //    //Console.WriteLine(car.BrandId);
            //}

            //Console.WriteLine("--------BrandId si 1 olanlar----------------------");

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("--------ColorId si 2 olanlar----------------------");

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}//Resulttan önce

            // Car car = new Car() { CarId = 7, BrandId = 4, ColorId = 3, DailyPrice = 275, ModelYear = 2015, Description = "Terra" };
            // carManager.Add(car);

            //Car updatedCar = carManager.GetById(7);
            //updatedCar.BrandId = 3;
            //updatedCar.ColorId = 2;
            //updatedCar.DailyPrice = 300;
            //updatedCar.Description = "Corolla";
            //updatedCar.ModelYear = 2016;
            //carManager.Update(updatedCar);

            //Car deletedCar = carManager.GetById(7);
            //carManager.Delete(deletedCar);

            //Console.WriteLine("--------Detaylı Veriler----------------------");

            //foreach (var item in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(item.CarName + ", " + item.BrandName + ", " + item.ColorName + ", " + item.DailyPrice);
            //}//Resulttan önce

            Console.WriteLine("--------Detaylı Veriler----------------------");
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName + ", " + item.BrandName + ", " + item.ColorName + ", " + item.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Brand brand = new Brand() { BrandName = "Renault", BrandId=6 };
            //brandManager.Add(brand);

            //Brand updatedBrand = brandManager.GetById(6);
            //updatedBrand.BrandName = "Fiat";
            //brandManager.Update(updatedBrand);

            //Brand deletedBrand = brandManager.GetById(6);
            //brandManager.Delete(deletedBrand);

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.Write("BrandName= " + item.BrandName + ", BrandId=" + item.BrandId + "\n");
                //Console.WriteLine(car.BrandId);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Color color = new Color() { ColorId = 6, ColorName = "Turuncu" };
            //colorManager.Add(color);

            //Color updatedColor = colorManager.GetById(6);
            //updatedColor.ColorName = "Gri";
            //colorManager.Update(updatedColor);

            //Color deletedColor = colorManager.GetById(6);
            //colorManager.Delete(deletedColor);

            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine("ColorName= " + item.ColorName + ", ColorId= " + item.ColorId);
            //}

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine("ColorName= " + item.ColorName + ", ColorId= " + item.ColorId);
            }
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //var result = userManager.Add(new User { FirstName = "Veli", LastName = "Öğüt", Email = "veli@ogut.com.tr", Password = "321" });
            //Console.WriteLine(result.Message);

            //var result = userManager.Add(new User { FirstName = "V", LastName = "Öğüt", Email = "veli@ogut.com.tr", Password = "321" });
            //Console.WriteLine(result.Message);
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //var result = customerManager.Add(new Customer { CompanyName = "Öğüt Pazarlama", UserId = 1 });
            //Console.WriteLine(result.Message);

            //var updatedCustomer = customerManager.GetById(1);
            //updatedCustomer.Data.CompanyName = "Öğüt Pazarlma A.Ş.";
            //var result = customerManager.Update(updatedCustomer.Data);
            //Console.WriteLine(result.Message);

            customerManager.GetAll();
        }
    }
}
