# EF Migrations
## Why is removing a column more dangerous than adding one?
Adding a column just creates an empty space for new info, which doesn't hurt anything. Removing a column permanently deletes all the data inside it. This can effect relationships with other tables.

## Why are migrations preferred over manual SQL changes?
Migrations keep a history log of every change. Doing it manually is slow, easy to forget, and makes it impossible to "undo" changes safely across different computers.

## What could go wrong if two developers modify the schema without migrations?
Their databases will become different versions of the same project. Code that works for one developer will crash for the other because a table or column exists on one machine but not the other.

## Which of your schema changes would be risky in production, and why?
Adding new fields as it can contradict data already in the database. It can also cause empty data if adjustments of the new fields are not made in the methods and controllers.
