using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VUY9FY_HFT_2021221.Models
{
    [Table("artists")]
    public class artist
    {
        public artist() { }
        //eloadoid A zeneszám előadójának azonosítója(szám), ez a kulcs.
        //nev Az előadó(k) neve(szöveg). 
        //zenekar Az előadó zenekar-e vagy sem.Zenekar esetén 1, egyéni előadónál 0 (szám). 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("artist_id", TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Column("artist_name", TypeName = "string", Order = 1)]
        public string Name { get; set; }

        [Column("band", TypeName = "bool", Order = 2)]
        public bool IsBand { get; set; }
        [NotMapped]
        public virtual ICollection<song> Songs { get; set; }
    }
}
