using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using  Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IvScrumApi.Models
{
    public class User
    {      
        [Column("name")]
        [FromForm]
        public string Name { get; set; }
        [Key]
        [Column("id")]        
        public Guid? Id { get; set; }
        [Column("picture_url")]
        [FromForm]
        public string PictureUrl  { get; set; }
        [Column("trello_id")]
        [FromForm]
        public string TrelloId  { get; set; }
        [Column("email")]
        [FromForm]
        public string Email { get; set; }
        [Column("team")]
        [FromForm]
        public Guid Team {get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            str += @":: User ::
";
            str += $@"{nameof(Name)} {Name}
";
            str += $@"{nameof(Email)} {Email}
";
            str += $@"{nameof(Id)} {Id}
";
            str += $@"{nameof(PictureUrl)} {PictureUrl}
";
            str += $@"{nameof(TrelloId)} {TrelloId}
";
            return str;
        }
    }
}