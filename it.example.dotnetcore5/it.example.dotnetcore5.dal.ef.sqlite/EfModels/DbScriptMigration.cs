using System;
using System.Collections.Generic;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.sqlite.EfModels
{
    public partial class DbScriptMigration
    {
        public string MigrationId { get; set; }
        public string MigrationName { get; set; }
        public byte[] MigrationDate { get; set; }
    }
}
