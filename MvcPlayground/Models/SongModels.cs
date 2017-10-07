using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPlayground.Models
{
    public class Artist
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The artist cannot be nameless! This isn't the 12th century or something!")]
        [Display(Name = "Artist name")]
        public string Name { get; set; }
        [Display(Name = "Cover Image")]
        [DataType(DataType.ImageUrl)]
        public string CoverImg { get; set; }
    }

    public class Album
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "No nameless albums allowed!")]
        [Display(Name = "Album title")]
        public string Title { get; set; }
        public Artist Artist { get; set; }
        [Display(Name = "Album Art")]
        [DataType(DataType.ImageUrl)]
        public string CoverImg { get; set; }
        [Required(ErrorMessage = "Time exists and it is needed for albums!")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [ScaffoldColumn(false)]
        public Int64 Downloads { get; set; }
    }

    public class Song
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "A man has no name... But this song does!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "There can be no orphaned tracks. This isn't the real world!")]
        public Artist Artist { get; set; }
        [Required(ErrorMessage = "Select an album, or else!")]
        public Album Album { get; set; }
        [Display(Name = "Disc Nr.")]
        public Byte? DiscNr { get; set; }
        [Display(Name = "Track Nr.")]
        public Int16? TrackNr { get; set; }
        public float? Rating { get; set; }
        [Display(Description = "Categories for the track and how it makes you feel")]
        public string Comments { get; set; }
        [Display(Description = "Let's sing it all day until we hate it!")]
        public string Lyrics { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Duration)]
        public int Length { get; set; }
        [ScaffoldColumn(false)]
        public Int64 Downloads { get; set; }
    }
}