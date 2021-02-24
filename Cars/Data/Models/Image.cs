using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cars.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required] public string ImageSrc { get; set; }

        [Required] public string CarId { get; set; }

        [JsonIgnore] public Car Car { get; set; }
    }
}