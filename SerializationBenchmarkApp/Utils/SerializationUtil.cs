using System.IO;
using System.Text.Json;
using FastSerialization;
using MessagePack;
using ProtoBuf;
using SerializationBenchmarkApp.Models;

namespace SerializationBenchmarkApp.Utils
{
    public static class SerializationUtil
    {
        public static string JsonSerialization(SpotifyAlbum model)
        {
            return JsonSerializer.Serialize(model);
        }

        public static byte[] JsonSerializationBytes(SpotifyAlbum model)
        {
            return JsonSerializer.SerializeToUtf8Bytes(model);
        }

        public static byte[] ProtobufSerialization(SpotifyAlbum model)
        {
            using var memoryStream = new MemoryStream();

            ProtoBuf.Serializer.Serialize(memoryStream, model);

            return memoryStream.ToArray();
        }

        public static byte[] MessagePackSerialization(SpotifyAlbum model)
        {
            return MessagePackSerializer.Serialize(model);
        }
    }
}