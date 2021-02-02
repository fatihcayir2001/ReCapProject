using Business.Concerete;
using DataAccess.Abstract;
using DataAccess.Concerete.InMemory;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            Console.WriteLine("------------------------------------------");

            Console.WriteLine("1 numaralı araç ");
            var Id = carManager.GetById(1);
            foreach (var name in Id)
            {
                Console.WriteLine(name.Description);
            }

            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Arabalar");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Model adı: "+ car.Description + ", Model Yılı " + car.ModelYear + ", Renk kodu: " + car.ColorId + ", Marka Kodu: " +
                    car.BrandId + ", Fiyat: " + car.DailyPrice+ "$");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Eklendikten sonra");
            
            carManager.AddToDb(new Entites.Concerete.Car {Description="Hyundai",ModelYear=1999,DailyPrice=5000,BrandId=9,ColorId=3});

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Model adı: " + car.Description + ", Model Yılı " + car.ModelYear + ", Renk kodu: " + car.ColorId + ", Marka Kodu: " +
                    car.BrandId + ", Fiyat: " + car.DailyPrice + "$");
                
            }
            

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silindikten Sonra");

            carManager.DeleteFromDb(new Entites.Concerete.Car { CarId =4});

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Model adı: " + car.Description + ", Model Yılı " + car.ModelYear + ", Renk kodu: " + car.ColorId + ", Marka Kodu: " +
                    car.BrandId + ", Fiyat: " + car.DailyPrice + "$");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Güncellendikten sonra");

            carManager.UpdateToDb(new Entites.Concerete.Car { CarId = 1,ColorId=3,BrandId=2,ModelYear=2005,Description="Scania",DailyPrice=5000 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Model adı: " + car.Description + ", Model Yılı " + car.ModelYear + ", Renk kodu: " + car.ColorId + ", Marka Kodu: " +
                    car.BrandId + ", Fiyat: " + car.DailyPrice+"$");
            }

        }
    }
}
