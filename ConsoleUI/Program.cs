using Business.Concerete;
using DataAccess.Abstract;
using DataAccess.Concerete.EntityFramework;
using DataAccess.Concerete.InMemory;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new DataAccess.Concerete.EntityFramework.EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            



            Console.WriteLine("------------------------------------------");

            Console.WriteLine("1 markalı araç ");
            carManager.GetCarsByBrandId(1);


            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Arabalar");

            foreach (var car in carManager.GetAll())
            {
                //var brands = brandManager.GetBrands();
                var brand = brandManager.GetBrandNameById(car.BrandId);


                Console.WriteLine(" Model adı: {0}, Model Yılı: {1}, Renk kodu: {2} , Marka Kodu: {3}  Fiyat: {4}", brand.BrandName, car.ModelYear,
                car.ColorId, car.BrandId, car.DailyPrice);


            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Eklendikten sonra");
            
            //carManager.AddToDb(new Entites.Concerete.Car {Description="Hyundai",ModelYear=1999,DailyPrice=5000,BrandId=3,ColorId=3});

            foreach (var car in carManager.GetAll())
            {
                var brand = brandManager.GetBrandNameById(car.BrandId);
                Console.WriteLine(" Model adı: {0}, Model Yılı: {1}, Renk kodu: {2} , Marka Kodu: {3}  Fiyat: {4}", brand.BrandName, car.ModelYear,
                    car.ColorId, car.BrandId, car.DailyPrice);
            }


            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silindikten Sonra");

            //carManager.DeleteFromDb(new Entites.Concerete.Car { CarId =4});

            foreach (var car in carManager.GetAll())
            {
                var brand = brandManager.GetBrandNameById(car.BrandId);
                Console.WriteLine(" Model adı: {0}, Model Yılı: {1}, Renk kodu: {2} , Marka Kodu: {3}  Fiyat: {4}", brand.BrandName, car.ModelYear,
                    car.ColorId, car.BrandId, car.DailyPrice);
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Güncellendikten sonra");

            carManager.UpdateToDb(new Entites.Concerete.Car { CarId = 1,ColorId=3,BrandId=2,ModelYear=2005,Description="Scania",DailyPrice=5000 });
            foreach (var car in carManager.GetAll())
            {
                var brand = brandManager.GetBrandNameById(car.BrandId);
                Console.WriteLine(" Model adı: {0}, Model Yılı: {1}, Renk kodu: {2} , Marka Kodu: {3}  Fiyat: {4}",brand.BrandName,car.ModelYear,
                    car.ColorId,car.BrandId,car.DailyPrice);
            }

        }
    }
}

