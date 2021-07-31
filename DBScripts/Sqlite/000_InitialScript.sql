CREATE TABLE IF NOT EXISTS `DbScriptMigration` (
				`MigrationId` varchar(38) NOT NULL PRIMARY KEY,
				`MigrationName` varchar(1000) NOT NULL,
				`MigrationDate` datetime NOT NULL
			);


INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT hex(randomblob(16)),'000_InitialScript.sql',datetime('now')) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '000_InitialScript.sql'
) LIMIT 1;