
# distributed in-memory cache
The main feature of Redis is a distributed in-memory key/value data store. 

## It supports transactions through five commands.
- DISCARD
- EXEC
- MULTI
- UNWATCH
- WATCH

Using the above command sets, we can achieve atomic transactions across multiple records.
Meaning a group of commands can execute as a single execution step or unit. 
This guarantees that:
1. all the commands part of a transaction will execute in sequence. 
And unless the transaction is complete, the records which are part of this transaction cannot be modified by another parallel command.

2. either all the commands are processes successfully, or none of them will be processed at all.

This feature somewhat makes it a candidate for a persistent data store with the ability to create a relational data structure and keep them in sync.
As well as update the relational records under a single atomic transaction. 
Hence I can see examples where applications use it as a database.
But even without transactions, we can use it as a no-SQL database. 


## Unlike Memcached, Redis supports multiple data structures:
* Strings – a simple string as a value
* Hashes – a key-value pair as a value
* Lists – a list of items
* Sets – an unordered collection of string
* Sorted sets kind of a sorted set


Apart from the above-defined data structures, 
it also supports complex data structures like bitmaps, hyperloglogs, and geospatial indexes.
And last but not least streams.
