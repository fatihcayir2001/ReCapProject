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
            //CarIdTest(carManager);
            //CarAddTest(carManager);
            //CarDeleteTest(carManager);
            //CarUpdateTest(carManager);

            //ListCars(carManager);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result1 = rentalManager.GetRentalDetails();
            //foreach (var car in result1.Data)
            //{
            //    Console.WriteLine(car.CustomerFirstName);
            //}
            
            var result1 = rentalManager.GetById(5);
            
            result1.Data.RentDate = DateTime.Now;
            result1.Data.CustomerId = 3;
            result1.Data.CarId = 3;
            var message =rentalManager.Update(result1.Data);
            Console.WriteLine(message.Message);

            rentalManager.Delete(result1.Data);
        }

        
        private static void ListCars(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {

                Console.WriteLine(" Model adı: {0}, Renk : {1} ,Fiyat: {3}, Model: {2}  ", car.BrandName, car.ColorName, car.Description, car.DailyPrice);
            }
        }

        private static void CarUpdateTest(CarManager carManager)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Güncellendikten sonra");
            

            carManager.Update(new Entites.Concerete.Car { CarId = 1, ColorId = 3, BrandId = 2, ModelYear = 2005, Description = "Scania", DailyPrice = 5000 });
            foreach (var car in carManager.GetCarDetails().Data)
            {
                
                Console.WriteLine(" Model adı: {0}, Renk : {1} , Açıklama: {2}  Fiyat: {3}", car.BrandName,car.ColorName,car.Description,car.DailyPrice);
            }
        }

        private static void CarDeleteTest(CarManager carManager)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silindikten Sonra");
            carManager.Delete(new Entites.Concerete.Car { CarId = 15 });

            foreach (var car in carManager.GetCarDetails().Data)
            {

                Console.WriteLine(" Model adı: {0}, Renk : {1} , Açıklama: {2}  Fiyat: {3}", car.BrandName, car.ColorName, car.Description, car.DailyPrice);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Eklendikten sonra");
            carManager.Add(new Entites.Concerete.Car { Description = "Hyundai", ModelYear = 1999, DailyPrice = 5000, BrandId = 3, ColorId = 3 });

            foreach (var car in carManager.GetCarDetails().Data)
            {

                Console.WriteLine(" Model adı: {0}, Renk : {1} , Açıklama: {2}  Fiyat: {3}", car.BrandName, car.ColorName, car.Description, car.DailyPrice);
            }
        }

        private static void CarIdTest(CarManager carManager)
        {
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("1 numaralı araç ");
            carManager.GetByCarId(1);
        }




    }
}

