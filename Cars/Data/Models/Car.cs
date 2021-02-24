using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cars.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Extras = new List<Extra>();
            this.Images = new List<Image>();
        }

        public string Id { get; set; }

        [Required] public string Make { get; set; }

        [Required] public string Model { get; set; }

        public string Description { get; set; }

        [Range(typeof(decimal), "0", "100000000")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        [JsonIgnore] public virtual ApplicationUser User { get; set; }

        public virtual IList<Extra> Extras { get; set; }

        public virtual IList<Image> Images { get; set; }
    }
}