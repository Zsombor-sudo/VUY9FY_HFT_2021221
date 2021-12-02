using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VUY9FY_HFT_2021221.Models
{
    [Table("artists")]
    public class artist
    {
        public artist() { }
        public artist(int id, string name, bool band)
        {
            Id = id;
            Name = name;
            IsBand = band;
        }

        //eloadoid A zeneszám előadójának azonosítója(szám), ez a kulcs.
        //nev Az előadó(k) neve(szöveg). 
        //zenekar Az előadó zenekar-e vagy sem. 
        //key

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //normal attributes
        public string Name { get; set; }

        public bool IsBand { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<song> Songs { get; set; }
    }
}
