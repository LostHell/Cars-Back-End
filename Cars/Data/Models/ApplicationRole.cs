using System;
using Microsoft.AspNetCore.Identity;

namespace Cars.Data.Models
{
    public class ApplicationRole:IdentityRole<string>
    {
        public ApplicationRole(string name):base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}