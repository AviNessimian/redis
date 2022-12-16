# Pub/Sub Engine

The following commands allow it to be a Pub/Sub engine.
- PSUBSCRIBE
- PUBLISH
- PUBSUB
- PUNSUBSCRIBE
- SUBSCRIBE
- UNSUBSCRIBE


Redis implements the publish/subscribe paradigm through PUBLISH, SUBSCRIBE and UNSUBSCRIBE commands.
The Pub/Sub in Redis is topic-based, where multiple subscribers can subscribe to a single topic or many topics.
The relationship between subscribers and the topic is many to many.
The topic is named channel in Redis, but conceptually it’s the same as a topic in other Pub/Sub echo systems like RabbitMQ. 
And on the other side, any publisher can publish a message to any topic/channel.

Redis also supports pattern matching subscriptions. 
Pattern matching subscribe and unsubscribe is done through commands PSUBSCRIBE and PUNSUBSCRIBE.
