using System;
using System.Collections.Generic;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.mysql.EfModels
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
