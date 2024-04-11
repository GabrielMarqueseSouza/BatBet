using System;
using System.Collections.Generic;

namespace BatBetDomain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
