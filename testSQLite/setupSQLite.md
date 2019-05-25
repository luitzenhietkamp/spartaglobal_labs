## Setting up a SQLite database
### Creating the database
In PowerShell (or Command Prompt):
```
sqlite3 testdb
```

### Creating the table
```sql
CREATE TABLE spartans (
id INTEGER PRIMARY KEY,
name TEXT NOT NULL);
```

### Inserting a row

```sql
INSERT INTO spartans (name) VALUES ("Luitzen");
```

### Reading the data
```sql
SELECT * FROM spartans;
```

### Exit SQLite3
Use Control-C:
```
^C
```

### Start SQLite 3 with the database

```
sqlite3 testdb
```

### Insert some more data and read the data
```sql
INSERT INTO spartans (name) VALUES ("Jaspreet");
INSERT INTO spartans (name) VALUES ("Seb");
INSERT INTO spartans (name) VALUES ("Li");

SELECT * FROM spartans;
```
### Exit SQLite3
Use `.exit`:
```
.exit
```

### Backup the database
```
sqlite3 testdb .dump > testdb.sql

```

### Delete database
```
Remove-Item testdb
```

### Restore database
```
cmd
sqlite3 testdb < testdb.sql
exit
```

### SQLite With Northwind

Download .sql script specifically for SQLite for Northwind

Import with
```
sqlite3 Northwind.db < InstallNorthwind.sql
```
