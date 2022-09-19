using System.IO;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using MessagePack;
using ProtoBuf;
using SerializationBenchmarkApp.Models;
using SerializationBenchmarkApp.Utils;

namespace SerializationBenchmarkApp.Benchmarks
{
    [MemoryDiagnoser]
    public class DeserializationBenchmark
    {
        private readonly string _jsonString;
        private readonly byte[] _jsonBytes;
        private readonly byte[] _bytesAvroSolTechnology;
        private readonly byte[] _bytesProtobuf;
        private readonly byte[] _bytesProtobufProtofile;
        private readonly byte[] _bytesAvroWithAvsc;
        private readonly byte[] _bytesMessagePack;

        public DeserializationBenchmark()
        {
            var model = ModelGenerator.GenerateTestModel();
            var modelProto = ModelGenerator.GenerateTestModelProto();
            

            _jsonString = SerializationUtil.JsonSerialization(model);
            _jsonBytes = SerializationUtil.JsonSerializationBytes(model);
            _bytesProtobuf = SerializationUtil.ProtobufSerialization(model);
            _bytesMessagePack = SerializationUtil.MessagePackSerialization(model);
            _bytesProtobufProtofile = modelProto.ToByteArray();
        }

        [Benchmark]
        public void JsonDeserialization()
        {
            var testModel = JsonSerializer.Deserialize<SpotifyAlbum>(_jsonString);
        }

        [Benchmark]
        public void JsonBytesDeserialization()
        {
            var testModel = JsonSerializer.Deserialize<SpotifyAlbum>(_jsonBytes);
        }

        [Benchmark]
        public void ProtobufDeserialization()
        {
            using var stream = new MemoryStream(_bytesProtobuf);

            var testModel = Serializer.Deserialize<SpotifyAlbum>(stream);
        }

        [Benchmark]
        public void ProtobufDeserializationWithProtoFile()
        {
            var testModel = SpotifyAlbumProto.Parser.ParseFrom(_bytesProtobufProtofile);
        }

        [Benchmark]
        public void MessagePackDeserialization()
        {
            var testModel = MessagePackSerializer.Deserialize<SpotifyAlbum>(_bytesMessagePack);
        }
    }
}