using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IvScrumApi.Models
{
    public class Backlog
    {
        [JsonIgnore]
        [Key]
        [Column("id")]
        public Guid? Id {get; set; }
        [Column("blocking")]
        public int Blocking {get; set; }
        [Column("major")]
        public int Major { get; set; }
        [Column("minor")]
        public int Minor { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }
        [JsonIgnore]
        [Column("team_id")]
        public Guid TeamId { get; set; }
        public override string ToString()
        {
            string str = "";
            str += $@"Blocking: {Blocking} - Major: {Major} - Minor: {Minor}
";            
            str += $@"Team ID: {TeamId}
";            
            str += $"Date: {Date}";
            return str;
        }

    }
}