using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class UserModel
    {
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        [BsonId]
        public string userId { get; set; }
    }
}
