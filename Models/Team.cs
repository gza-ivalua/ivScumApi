using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Column("trello")]
        [FromForm]
        public string TrelloId  { get; set; }         
        public ICollection<User> Devs { get; set; }
        public ICollection<Backlog> Backlogs { get; set; }
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