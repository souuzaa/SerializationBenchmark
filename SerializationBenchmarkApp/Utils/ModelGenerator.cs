using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Google.Protobuf.Collections;
using SerializationBenchmarkApp.Models;

namespace SerializationBenchmarkApp.Utils
{
    public static class ModelGenerator
    {
        private static SpotifyAlbum _model;

        public static SpotifyAlbum GenerateTestModel()
        {
            if (_model != null)
                return _model;

            var fixture = new Fixture();

            _model = fixture.Create<SpotifyAlbum>();

            return _model;
        }

        public static SpotifyAlbumProto GenerateTestModelProto()
        {
            var model = GenerateTestModel();

            var artistsProto = new RepeatedField<ArtistProto>();

            foreach (var artist in model.Artists)
            {
                var externalUrls = new ExternalUrlsProto
                {
                    Spotify = artist.ExternalUrls.Spotify
                };

                var artistProto = new ArtistProto
                {
                    Href = artist.Href,
                    Id = artist.Id,
                    Name = artist.Name,
                    Type = artist.Type,
                    Uri = artist.Uri,
                    ExternalUrls = externalUrls
                };

                artistsProto.Add(artistProto);
            }

            var itemsTrackProto = new RepeatedField<ItemProto>();

            foreach (var item in model.Tracks.Items)
            {
                var artistsTrackProto = item.Artists.Select(x => new ArtistProto
                {
                    ExternalUrls = new ExternalUrlsProto
                    {
                        Spotify = x.ExternalUrls.Spotify
                    },
                    Href = x.Href,
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Uri = x.Uri
                });

                var itemTrackProto = new ItemProto
                {
                    ExternalUrls = new ExternalUrlsProto
                    {
                        Spotify = item.ExternalUrls.Spotify
                    },
                    DiscNumber = item.DiscNumber,
                    DurationMs = item.DurationMs,
                    Explicit = item.Explicit,
                    Href = item.Href,
                    Id = item.Id,
                    Name = item.Name,
                    PreviewUrl = item.PreviewUrl,
                    TrackNumber = item.TrackNumber,
                    Type = item.Type,
                    Uri = item.Uri,
                    Artists =
                    {
                        artistsTrackProto
                    },
                    AvailableMarkets =
                    {
                        model.AvailableMarkets
                    }
                };

                itemsTrackProto.Add(itemTrackProto);
            }

            var copyrightsProto = new RepeatedField<CopyrightProto>();

            foreach (var copyright in model.Copyrights)
            {
                var copyrightProto = new CopyrightProto
                {
                    Type = copyright.Type,
                    Text = copyright.Text
                };

                copyrightsProto.Add(copyrightProto);
            }

            var imagesProto = new RepeatedField<ImageProto>();

            foreach (var image in model.Images)
            {
                var imageProto = new ImageProto
                {
                    Height = image.Height,
                    Url = image.Url,
                    Width = image.Width
                };

                imagesProto.Add(imageProto);
            }

            var modelProto = new SpotifyAlbumProto
            {
                AlbumType = model.AlbumType,
                Artists =
                {
                    artistsProto
                },
                Href = model.Href,
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                ExternalUrls = new ExternalUrlsProto
                {
                    Spotify = model.ExternalUrls.Spotify
                },
                Uri = model.Uri,
                ExternalIds = new ExternalIdsProto
                {
                    Upc = model.ExternalIds.Upc
                },
                Popularity = model.Popularity,
                ReleaseDate = model.ReleaseDate,
                ReleaseDatePrecision = model.ReleaseDatePrecision,
                Tracks = new TracksProto
                {
                    Href = model.Tracks.Href,
                    Limit = model.Tracks.Limit,
                    Next = model.Tracks.Next,
                    Offset = model.Tracks.Offset,
                    Previous = model.Tracks.Previous,
                    Total = model.Tracks.Total,
                    Items =
                    {
                        itemsTrackProto
                    }
                },
                AvailableMarkets =
                {
                    model.AvailableMarkets
                },
                Copyrights =
                {
                    copyrightsProto
                },
                Genres =
                {
                    model.Genres
                },
                Images =
                {
                    imagesProto
                }
            };

            return modelProto;
        }
    }
}