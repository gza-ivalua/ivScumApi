using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using  Microsoft.AspNetCore.Mvc;

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
        [Column("trello")]
        [FromForm]
        public string TrelloId  { get; set; }       
        [Column("trigram")]
        [FromForm]
        public string Trigram  { get; set; }        
        [Column("team")]
        [FromForm]
        public Guid Team {get; set; }
        [Column("trello")]
        [FromForm]
        public string Trello {get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            str += @":: User ::
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