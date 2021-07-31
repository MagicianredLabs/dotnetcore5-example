using System;
using System.Collections.Generic;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.mysql.EfModels
{
    public partial class Dbscriptmigration
    {
        public string MigrationId { get; set; }
        public string MigrationName { get; set; }
        public DateTime MigrationDate { get; set; }
    }
}
