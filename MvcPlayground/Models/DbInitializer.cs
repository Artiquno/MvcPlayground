using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SongsDbContext>
    {
        protected override void Seed(SongsDbContext context)
        {
            context.Genres.AddRange(new List<Genre>
            {
                new Genre
                {
                    Id = 1, 
                    Name = "Hard Rock"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Grunge"
                },
                new Genre
                {
                    Id = 3,
                    Name = "GlitchHop"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Electronic"
                }
            });
            context.Artists.AddRange(new List<Artist>
            {
                new Artist
                {
                    Id = 1,
                    Name = "Audioslave",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 1,
                            Title = "Audioslave",
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 1,
                                    Title = "Like a Stone",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 5,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Audioslave - Like a Stone.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 2,
                                    Title = "Shadow on the Sun",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 7,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Audioslave - Shadow on the Sun.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        }
                    }
                },
                new Artist
                {
                    Id = 2,
                    Name = "Radiohead",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 2,
                            Title = "OK Computer",
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 3,
                                    Title = "Paranoid Android",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 2,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Radiohead - Paranoid Android.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 4,
                                    Title = "Karma Police",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 6,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Radiohead - Karma Police.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        }
                    }
                },
                new Artist
                {
                    Id = 3,
                    Name = "KOAN Sound",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 3,
                            Title = "The Adventures of Mr. Fox",
                            
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 5,
                                    Title = "Introvert",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 4,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "KOAN Sound - Introvert.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 6,
                                    Title = "Sly Fox",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 3,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "KOAN Sound - Sly Fox.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 7,
                                    Title = "80s Fitness",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 1,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "KOAN Sound - 80s Fitness.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        },
                        new Album
                        {
                            Id = 4,
                            Title = "Funk Blaster",
                            
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 8,
                                    Title = "Funk Blaster",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 1,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "KOAN Sound - Funk Blaster.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 9,
                                    Title = "Meanwhile, In The Future",
                                    Length = 0,
                                    GenreId = 2,
                                    TrackNr = 4,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "KOAN Sound - Meanwhile, In The Future.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        }
                    }
                },
                new Artist
                {
                    Id = 4,
                    Name = "Led Zeppelin",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 5,
                            Title = "Physical Graffiti",
                            
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 10,
                                    Title = "Kashmir",
                                    Length = 0,
                                    GenreId = 3,
                                    TrackNr = 6,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Led Zeppelin - Kashmir.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 11,
                                    Title = "Down By The Seaside",
                                    Length = 0,
                                    GenreId = 3,
                                    TrackNr = 1,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Led Zeppelin - Down By The Seaside.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        }
                    }
                },
                new Artist
                {
                    Id = 5,
                    Name = "Soundgarden",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 6,
                            Title = "Superunkown",
                            
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 12,
                                    Title = "Fell On Black Days",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 3,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Fell On Black Days.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 13,
                                    Title = "Superunknown",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 5,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Superunknown.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 14,
                                    Title = "Black Hole Sun",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 7,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Black Hole Sun.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        },
                        new Album
                        {
                            Id = 7,
                            Title = "Badmotorfinger",
                            
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Id = 15,
                                    Title = "Rusty Cage",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 1,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Rusty Cage.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 16,
                                    Title = "Outshined",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 2,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Outshined.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                },
                                new Song
                                {
                                    Id = 17,
                                    Title = "Searching With My Good Eye Closed",
                                    Length = 0,
                                    GenreId = 1,
                                    TrackNr = 7,
                                    DiscNr = 1,
                                    File = new File
                                    {
                                        Filename = "Soundgarden - Searching With My Good Eye Closed.mp3",
                                        Path = "/Public/Music",
                                        MimeType = "audio/mp3"
                                    },
                                    Comments = "",
                                    Lyrics = "",
                                    Rating = 5
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}