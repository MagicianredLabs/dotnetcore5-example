CREATE TABLE IF NOT EXISTS `DbScriptMigration` (
				`MigrationId` char(38) NOT NULL,
				`MigrationName` varchar(1000) NOT NULL,
				`MigrationDate` datetime NOT NULL,
			PRIMARY KEY (`MigrationId`)
			) ENGINE=InnoDB;


INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT UUID(),'000_InitialScript.sql',NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '000_InitialScript.sql'
) LIMIT 1;