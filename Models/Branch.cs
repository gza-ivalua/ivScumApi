using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace IvScrumApi.Models
{    
    public enum BranchStatus{
        [EnumMember(Value = "open")]
        Opened,
        [EnumMember(Value = "locked")]
        Locked
    }
    public class Branch
    {           
        [Column("version")]
        [FromForm]
        public string Version { get; set; }
        [Key]
        [Column("id")]        
        public Guid? Id { get; set; }
        [Column("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BranchStatus Status {get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            str += @":: Team ::
";
            str += $@"{nameof(Id)} {Id}
";
            str += $@"{nameof(Version)} {Version}
";
            str += $@"{nameof(Status)} {Status}
";
            return str;
        }
    }
}