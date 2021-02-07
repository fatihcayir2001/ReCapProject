using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class CarDetailDto:IDto
    {
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }
    }
}
