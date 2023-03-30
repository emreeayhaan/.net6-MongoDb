﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Muvekkil.Collection
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
