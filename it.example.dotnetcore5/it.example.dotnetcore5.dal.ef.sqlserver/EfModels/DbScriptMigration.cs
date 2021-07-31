using System;
using System.Collections.Generic;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.sqlserver.EfModels
{
    public partial class DbScriptMigration
    {
        public Guid MigrationId { get; set; }
        public string MigrationName { get; set; }
        public DateTime MigrationDate { get; set; }
    }
}
