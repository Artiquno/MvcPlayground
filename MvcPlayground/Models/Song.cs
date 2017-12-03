namespace MvcPlayground.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Song
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int FileId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        
        [ScaffoldColumn(false)]
        public int Length { get; set; }
        public int? TrackNr { get; set; }
        public int? DiscNr { get; set; }
        public int Rating { get; set; }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        public string Lyrics { get; set; }

        [StringLength(256)]
        public string Cover { get; set; }
        [ScaffoldColumn(false)]
        public int Downloads { get; set; }

        public virtual Album Album { get; set; }
        public virtual File File { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
