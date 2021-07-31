using System;
using System.Collections.Generic;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.mysql.EfModels
{
    public partial class Posttag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
