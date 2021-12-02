using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VUY9FY_HFT_2021221.Models
{
    [Table("lists")]
    public class list
    {
        public list() { }
 
        [Key]
        
        public int Year { get; set; }

        [Key]
        
        public int Score { get; set; }

        
        public int SongId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual song Song { get; set; }

        public static implicit operator list(List<list> v)
        {
            throw new NotImplementedException();
        }
    }
}
