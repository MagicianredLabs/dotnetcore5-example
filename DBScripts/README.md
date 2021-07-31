# DBScript  

## Description  
This folder contains the sql scripts to create the database and table that we use in the application.  

For the sql server I use the system in this repository [*sqlserver-db-script-migration-system*](https://github.com/Magicianred/sqlserver-db-script-migration-system)  

## Instruction  

### SQL Server  
1. Create a new Database in Sql Server  
2. Run scripts in the folder DBScripts\MsSQL\:  
	- 000_InitialScript.sql  
	- 000b_CreateUniqueCostraintForMigrationName.sql  
	- 001_create_posts_table.sql  

### MySQL  
1. Create a new Database in MySQL  
2. Run scripts in the folder DBScripts\MySQL\:  
	- 000_InitialScript.sql  
	- 001_create_posts_table.sql  

### Sqlite  
1. Create a new file database Sqlite  
2. Run scripts in the folder DBScripts\Sqlite\:  
	- 000_InitialScript.sql  
	- 001_create_posts_table.sql  

Enjoy your code!  
