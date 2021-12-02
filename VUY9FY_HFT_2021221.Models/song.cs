﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VUY9FY_HFT_2021221.Models
{
    [Table("songs")]
    public class song
    {
        //constructors
        public song() { }
        public song(int id, string title, int date)
        {
            ArtistId = id;
            Title = title;
            Release = date;
        }
        public song(int id, string title)
        {
            ArtistId = id;
            Title = title;
        }

        //keys
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int SongId { get; set; }

        [ForeignKey(nameof(artist))]
        
        public int ArtistId { get; set; }

        //normal attributes
        
        public string Title { get; set; }
        
        public int Release { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual artist Artist { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual list Score { get; set; }
    }
}
