using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImg { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public string CoverImg { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Int64 Downloads { get; set; }
    }

    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Byte? DiscNr { get; set; }
        public Int16? TrackNr { get; set; }
        public float? Rating { get; set; }
        public string Comments { get; set; }
        public string Lyrics { get; set; }
        public int Length { get; set; }
        public Int64 Downloads { get; set; }
    }
}