using MessagePack;
using ProtoBuf;

namespace SerializationBenchmarkApp.Models
{
    [ProtoContract]
    [MessagePackObject]
    public class SpotifyAlbum
    {
        [ProtoMember(1)]
        [Key(0)]
        public string AlbumType { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public Artist[] Artists { get; set; }
        [ProtoMember(3)]
        [Key(2)]
        public string[] AvailableMarkets { get; set; }
        [ProtoMember(4)]
        [Key(3)]
        public Copyright[] Copyrights { get; set; }
        [ProtoMember(5)]
        [Key(4)]
        public ExternalIds ExternalIds { get; set; }
        [ProtoMember(6)]
        [Key(5)]
        public ExternalUrls ExternalUrls { get; set; }
        [ProtoMember(7)]
        [Key(6)]
        public string[] Genres { get; set; }
        [ProtoMember(8)]
        [Key(7)]
        public string Href { get; set; }
        [ProtoMember(9)]
        [Key(8)]
        public string Id { get; set; }
        [ProtoMember(10)]
        [Key(9)]
        public Image[] Images { get; set; }
        [ProtoMember(11)]
        [Key(10)]
        public string Name { get; set; }
        [ProtoMember(12)]
        [Key(11)]
        public long Popularity { get; set; }
        [ProtoMember(13)]
        [Key(12)]
        public string ReleaseDate { get; set; }
        [ProtoMember(14)]
        [Key(13)]
        public string ReleaseDatePrecision { get; set; }
        [ProtoMember(15)]
        [Key(14)]
        public Tracks Tracks { get; set; }
        [ProtoMember(16)]
        [Key(15)]
        public string Type { get; set; }
        [ProtoMember(17)]
        [Key(16)]
        public string Uri { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class Tracks
    {
        [ProtoMember(1)]
        [Key(0)]
        public string Href { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public Item[] Items { get; set; }
        [ProtoMember(3)]
        [Key(2)]
        public long Limit { get; set; }
        [ProtoMember(4)]
        [Key(3)]
        public string Next { get; set; }
        [ProtoMember(5)]
        [Key(4)]
        public long Offset { get; set; }
        [ProtoMember(6)]
        [Key(5)]
        public string Previous { get; set; }
        [ProtoMember(7)]
        [Key(6)]
        public long Total { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class Item
    {
        [ProtoMember(1)]
        [Key(0)]
        public Artist[] Artists { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public string[] AvailableMarkets { get; set; }
        [ProtoMember(3)]
        [Key(2)]
        public long DiscNumber { get; set; }
        [ProtoMember(4)]
        [Key(3)]
        public long DurationMs { get; set; }
        [ProtoMember(5)]
        [Key(4)]
        public bool Explicit { get; set; }
        [ProtoMember(6)]
        [Key(5)]
        public ExternalUrls ExternalUrls { get; set; }
        [ProtoMember(7)]
        [Key(6)]
        public string Href { get; set; }
        [ProtoMember(8)]
        [Key(7)]
        public string Id { get; set; }
        [ProtoMember(9)]
        [Key(8)]
        public string Name { get; set; }
        [ProtoMember(10)]
        [Key(9)]
        public string PreviewUrl { get; set; }
        [ProtoMember(11)]
        [Key(10)]
        public long TrackNumber { get; set; }
        [ProtoMember(12)]
        [Key(13)]
        public string Type { get; set; }
        [ProtoMember(13)]
        [Key(14)]
        public string Uri { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class Image
    {
        [ProtoMember(1)]
        [Key(0)]
        public long Height { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public string Url { get; set; }
        [ProtoMember(3)]
        [Key(2)]
        public long Width { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]

    public class ExternalIds
    {
        [ProtoMember(1)]
        [Key(0)]
        public string Upc { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class Copyright
    {
        [ProtoMember(1)]
        [Key(0)]
        public string Text { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public string Type { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class Artist
    {
        [ProtoMember(1)]
        [Key(0)]
        public ExternalUrls ExternalUrls { get; set; }
        [ProtoMember(2)]
        [Key(1)]
        public string Href { get; set; }
        [ProtoMember(3)]
        [Key(2)]
        public string Id { get; set; }
        [ProtoMember(4)]
        [Key(3)]
        public string Name { get; set; }
        [ProtoMember(5)]
        [Key(4)]
        public string Type { get; set; }
        [ProtoMember(6)]
        [Key(5)]
        public string Uri { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public class ExternalUrls
    {
        [ProtoMember(1)]
        [Key(0)]
        public string Spotify { get; set; }
    }
}