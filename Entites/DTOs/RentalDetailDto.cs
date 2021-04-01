using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CarModel { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int BrandId { get; set; }

    }
}
