using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cars.Data.Models
{
    public class Extra
    {
        public Extra()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required] public string Name { get; set; }

        public string CarId { get; set; }

        [JsonIgnore] public Car Car { get; set; }
    }
}