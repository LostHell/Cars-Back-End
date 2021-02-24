using System;
using System.Collections.Generic;

namespace Cars.ViewModels.CarsViewModels.Outputs
{
    public class CarOutputViewModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public List<ExtraOutputViewModel> Extras { get; set; }
        
        public List<ImageOutputViewModel> Images { get; set; }
    }
}