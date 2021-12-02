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
        [Column("year", TypeName = "int", Order = 0)]
        public int Year { get; set; }

        [Key]
        [Column("score", TypeName = "int", Order = 1)]
        public int Score { get; set; }

        [Column("song_id", TypeName = "int", Order = 2)]
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
