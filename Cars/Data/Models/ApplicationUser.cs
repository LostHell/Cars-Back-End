using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Cars.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cars = new List<Car>();
        }

        [Required] public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string City { get; set; }

        public virtual IList<Car> Cars { get; set; }
    }
}