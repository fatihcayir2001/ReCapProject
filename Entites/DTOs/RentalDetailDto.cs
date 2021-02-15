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
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
