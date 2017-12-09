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
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "File")]
        public int FileId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        
        [ScaffoldColumn(false)]
        public int Length { get; set; }
        [Display(Name = "Track Nr.")]
        public int? TrackNr { get; set; }
        [Display(Name = "Disc Nr.")]
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
