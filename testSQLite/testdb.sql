PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE spartans (
id INTEGER PRIMARY KEY,
name TEXT NOT NULL);
INSERT INTO "spartans" VALUES(1,'Luitzen');
INSERT INTO "spartans" VALUES(2,'Jaspreet');
INSERT INTO "spartans" VALUES(3,'Seb');
INSERT INTO "spartans" VALUES(4,'Li');
COMMIT;
