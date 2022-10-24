using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace IvScrumApi.Models
{
    public class User
    {      
        [Column("name")]                                
        public string Name { get; set; }
        [Key]
        [Column("id")]     
        public Guid? Id { get; set; }                     
        [Column("trigram")]        
        public string Trigram  { get; set; }          
        [Column("team")]
        public Guid TeamId {get; set; }
        [Column("trello")]
        public string Trello {get; set; }
        [Column("here")]        
        public bool Here {get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            str += @":: User ::
";
            str += $@"{nameof(Name)} {Name}
";
            str += $@"{nameof(Id)} {Id}
"; 
            str += $@"{nameof(Here)} {Here}
"; 
            str += $@"{nameof(Trello)} {Trello}
"; 
            return str;
        }
    }
}