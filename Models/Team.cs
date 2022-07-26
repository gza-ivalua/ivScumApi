using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using  Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IvScrumApi.Models
{
    public class Team
    {      
        [Column("name")]
        [FromForm]
        public string Name { get; set; }
        [Key]
        [Column("id")]        
        public Guid? Id { get; set; }
        [Column("trello_id")]
        [FromForm]
        public string TrelloId  { get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            str += @":: Team ::
";
            str += $@"{nameof(Name)} {Name}
";
            str += $@"{nameof(Id)} {Id}
";
            str += $@"{nameof(TrelloId)} {TrelloId}
";
            return str;
        }
    }
}