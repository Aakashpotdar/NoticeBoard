using Microsoft.AspNetCore.Mvc;
using Model.Model;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardApp.Models
{
    public class NoteModel
    {
        [ForeignKey("UserModel")]
        public virtual UserModel userInfo { get; set; }

        [BsonId]
        public string noteId { get; set; }

        public string titel { get; set; }
        
        public string description { get; set; }

        public string userId { get; set; }

        public bool archive { get; set; }

        public bool pinned { get; set; }

        public string image { get; set; }
    }
}
